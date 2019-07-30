﻿Imports System.Reflection
Imports CapaEntidad
Imports CapaNegocio

Public Class frm_principal
    Dim dtMenus As New DataTable

    Private Sub CargarMenus(id_Perfil As Int32)
        Try
            Dim lista As New List(Of Menu)
            Dim conexioNegocio As New ConexionNegocio()

            lista = conexioNegocio.getMenuPrincipal(id_Perfil)
            dtMenus = ConvertToDataTable(lista)

            'dtMenus.Load(dr) ' cargar data table a partior de un dataread
            For Each MenuPadre As DataRow In dtMenus.Select("men_Id_MenuPadre=0", "men_Posicion ASC")
                Dim Menu As ToolStripItem
                Menu = New ToolStripMenuItem()
                Menu.Name = MenuPadre("men_Id").ToString()
                Menu.Text = MenuPadre("men_Descripcion").ToString()
                Menu.Tag = MenuPadre("men_nombreFrm").ToString()
                'Averiguando si tiene Hijos o no
                If dtMenus.Select("men_Id_MenuPadre=" & MenuPadre("men_Id")).Length = 0 Then
                    'Sino tiene hijos lo agrego a la barra de menu principal
                    MenuPpal.Items.Add(Menu)
                Else
                    'Si tiene hijos llamo a la funcion recursiva y Agrego el Item sin Evento
                    MenuPpal.Items.Add(Menu)
                    AgregarMenuHijo(Menu)
                End If
            Next
            dtMenus.Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Shared Function ConvertToDataTable(Of T)(ByVal list As IList(Of T)) As DataTable
        Dim dt As New DataTable()
        Dim propiedades As PropertyInfo() = GetType(T).GetProperties
        For Each p As PropertyInfo In propiedades
            dt.Columns.Add(p.Name, p.PropertyType)
        Next
        For Each item As T In list
            Dim row As DataRow = dt.NewRow
            For Each p As PropertyInfo In propiedades
                row(p.Name) = p.GetValue(item, Nothing)
            Next
            dt.Rows.Add(row)
        Next
        Return dt
    End Function

    Private Sub AgregarMenuHijo(MenuItemPadre As ToolStripItem)
        Try
            Dim MenuPadre As ToolStripMenuItem = CType(MenuItemPadre, ToolStripMenuItem)
            'Obtengo el ID del menu Enviado para saber si tiene hijos o no
            Dim Id As String = MenuPadre.Name
            'Averiguando si tiene Hijos o no
            If dtMenus.Select("men_Id_MenuPadre=" & Id).Length = 0 Then
                'Si No tiene Hijos Solo Agrego el Evento
                AddHandler MenuPadre.Click, AddressOf AccionarMenu
            Else
                'Si Aun tiene Hijos
                For Each Menu As DataRow In dtMenus.Select("men_Id_MenuPadre=" & Id, "men_Posicion ASC")
                    Dim NuevoMenu As ToolStripItem
                    NuevoMenu = New ToolStripMenuItem()
                    NuevoMenu.Name = Menu("men_Id").ToString()
                    NuevoMenu.Text = Menu("men_Descripcion").ToString()
                    NuevoMenu.Tag = Menu("men_nombreFrm").ToString()
                    'Averiguo se es un separador
                    If Menu("men_Descripcion").ToString() = "-" Then
                        MenuPadre.DropDownItems.Add(NuevoMenu.Text)
                    Else
                        'Obtengo el ID del Menu del foreach
                        If dtMenus.Select("men_Id_MenuPadre=" & Menu("men_Id")).Length = 0 Then
                            'Sino tiene hijos lo agrego al Menu Padre
                            AddHandler NuevoMenu.Click, AddressOf AccionarMenu
                            MenuPadre.DropDownItems.Add(NuevoMenu)
                        Else
                            'Si tiene hijos llamo a la funcion recursiva y Agrego el Item sin Evento
                            MenuPadre.DropDownItems.Add(NuevoMenu)
                            AgregarMenuHijo(NuevoMenu)

                        End If
                    End If
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub AccionarMenu(sender As Object, e As EventArgs)
        Try
            If sender.GetType() = GetType(ToolStripMenuItem) Then
                Dim NombreFormulario As String = (CType(sender, ToolStripItem)).Tag.ToString()

                If String.IsNullOrEmpty(NombreFormulario) = True Then
                    Exit Sub
                End If
                Dim nombrecompleto As String = Application.ProductName & "." & NombreFormulario
                Dim FormInstanceType As Type = Type.GetType(nombrecompleto, True, True)
                Dim FRM As Object
                FRM = CType(Activator.CreateInstance(FormInstanceType), Form)

                If EstaAbierto(FRM) Then
                    Exit Sub
                Else
                    FRM.MdiParent = Me
                    FRM.StartPosition = FormStartPosition.CenterScreen
                    FRM.MinimizeBox = False
                    FRM.Show()
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Function EstaAbierto(ByVal Myform As Form) As Boolean
        Try
            EstaAbierto = False
            For Each objForm In My.Application.OpenForms
                If (Trim(objForm.Name) = Trim(Myform.Name)) Then
                    EstaAbierto = True
                End If
            Next
            Return EstaAbierto
        Catch ex As Exception
            EstaAbierto = False
        End Try
    End Function

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lbl_hora.Text = Date.Now.ToShortTimeString()
    End Sub

    Private Sub frm_principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim fecha As Date = Format(Now, "dd/MM/yyyy")
            Me.Text = "Sistema Informático de Automatización  de Pedidos"

            lbl_usuario.Text = usuarioSeccion.Nombres
            lbl_usuario_estado.Text = usuarioSeccion.Nombres
            lbl_fecha.Text = fecha

            'cargar el menu de la aplicación
            CargarMenus(usuarioSeccion.Id_perfil)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class