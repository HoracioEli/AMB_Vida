Public Class FPrincipal
    Private Sub FPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Conectarse()
        Call LlenarTipoContrato()

    End Sub

    Private Sub CboTipoContrato_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboTipoContrato.SelectedIndexChanged
        Call BuscarVariables()
        Call EliminarTablaAdherentes()
        Call EliminarCambios()
    End Sub

    Private Sub TxSAMaxima_Leave(sender As Object, e As EventArgs) Handles TxSAMaxima.Leave
        If IsNumeric(TxSAMaxima.Text) Then
            SAMaxima = TxSAMaxima.Text
        Else
            TxSAMaxima.Text = SAMaxima
        End If
        TxSAMaxima.Text = Format(CInt(SAMaxima), "#,###")
    End Sub

    Private Sub TxSAMinima_Leave(sender As Object, e As EventArgs) Handles TxSAMinima.Leave

        If IsNumeric(TxSAMinima.Text) Then
            SAMinima = TxSAMinima.Text
        Else
            TxSAMinima.Text = SAMinima
        End If
        TxSAMinima.Text = Format(CInt(SAMinima), "#,###")
    End Sub

    Private Sub TxEdadMaxima_Leave(sender As Object, e As EventArgs) Handles TxEdadMaxima.Leave
        If IsNumeric(TxEdadMaxima.Text) = False Then
            TxEdadMaxima.Text = EdadMaxima
        Else
            EdadMaxima = TxEdadMaxima.Text
        End If
    End Sub

    Private Sub TxEdadMinima_Leave(sender As Object, e As EventArgs) Handles TxEdadMinima.Leave
        If IsNumeric(TxEdadMinima.Text) = False Then
            TxEdadMinima.Text = EdadMinima
        Else
            EdadMinima = TxEdadMinima.Text
        End If

    End Sub

    Private Sub txEdadPermanencia_Leave(sender As Object, e As EventArgs) Handles txEdadPermanencia.Leave
        If IsNumeric(txEdadPermanencia.Text) = False Then
            txEdadPermanencia.Text = EdadPermanencia
        Else
            EdadPermanencia = txEdadPermanencia.Text
        End If

    End Sub

    Private Sub btnPaso1_ImportarVigentes_Click(sender As Object, e As EventArgs) Handles btnPaso1_ImportarVigentes.Click

        Call EliminarTablaAdherentes()

        Mensaje = "ANTES debe indicarse el TIPO DE CONTRATO"
        If CboTipoContrato.Text = Nothing Then
            MsgBox(Mensaje, MsgBoxStyle.OkCancel, "FALTA UN PASO")
            Mensaje = Nothing
            CboTipoContrato.Select()
            Exit Sub
        End If

        Mensaje = "Previo a realizar este paso es necesario que se haya descargado de POLICY el listado de adherentes vigentes"
        MsgBox(Mensaje, MsgBoxStyle.OkCancel, "BUSCAR ARCHIVO EXCEL EXPORTADO DE POLICY")
        If vbCancel = True Then
            Exit Sub
        End If

        OpenFileDialog1.ShowDialog()
        LbRutaPlantillaExcel.Text = OpenFileDialog1.FileName
        RutaPlantillaExcel = LbRutaPlantillaExcel.Text

        If LbRutaPlantillaExcel.Text = Nothing Then
            Exit Sub
        Else
            Call VolcarEnTablaVigentes()
        End If

    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Mensaje = "ANTES debe indicarse el TIPO DE CONTRATO"
        If CboTipoContrato.Text = Nothing Then
            MsgBox(Mensaje, MsgBoxStyle.OkCancel, "FALTA UN PASO")
            Mensaje = Nothing
            CboTipoContrato.Select()
            Exit Sub
        End If

        FuncionEnProceso = "Actualizar"
        ArchivoPlantilla = "Plantilla.xlsx"
        Call AbrirPlantillaExcel()

    End Sub

    Private Sub btnAltas_Click(sender As Object, e As EventArgs) Handles btnAltas.Click
        Mensaje = "ANTES debe indicarse el TIPO DE CONTRATO"
        If CboTipoContrato.Text = Nothing Then
            MsgBox(Mensaje, MsgBoxStyle.OkCancel, "FALTA UN PASO")
            Mensaje = Nothing
            CboTipoContrato.Select()
            Exit Sub
        End If
        FuncionEnProceso = "Altas"
        ArchivoPlantilla = "Plantilla.xlsx"
        Call AbrirPlantillaExcel()
    End Sub

    Private Sub btnBajas_Click(sender As Object, e As EventArgs) Handles btnBajas.Click
        Mensaje = "ANTES debe indicarse el TIPO DE CONTRATO"
        If CboTipoContrato.Text = Nothing Then
            MsgBox(Mensaje, MsgBoxStyle.OkCancel, "FALTA UN PASO")
            Mensaje = Nothing
            CboTipoContrato.Select()
            Exit Sub
        End If
        FuncionEnProceso = "Bajas"
        ArchivoPlantilla = "PlantillaBaja.xlsx"
        Call AbrirPlantillaExcel()
    End Sub

    Private Sub btn2_ImportarActualizado_Click(sender As Object, e As EventArgs) Handles btn2_ImportarActualizado.Click
        Mensaje = "ANTES debe indicarse el TIPO DE CONTRATO"
        If CboTipoContrato.Text = Nothing Then
            MsgBox(Mensaje, MsgBoxStyle.OkCancel, "FALTA UN PASO")
            Mensaje = Nothing
            CboTipoContrato.Select()
            Exit Sub
        End If

        If ArchivoPlantilla = Nothing Then
            Mensaje = "Previo a realizar este paso es necesario que se haya completado la PLANTILLA EXCEL registrando las BAJAS, ALTAS o el ACTUALIZADO"
            MsgBox(Mensaje, MsgBoxStyle.OkCancel, "BUSCAR PLANTILLA CON CAMBIOS A REALIZAR")
            If vbCancel = True Then
                Exit Sub
            End If
        End If


        Call Paso2_VolcarEnTablaActualizados()

    End Sub

    Private Sub CboTipoContrato_Leave(sender As Object, e As EventArgs) Handles CboTipoContrato.Leave
        TipoContrato = CboTipoContrato.Text
    End Sub

    Private Sub btnPaso3_ApellidoNombreSexo_Click(sender As Object, e As EventArgs) Handles btnPaso3_ApellidoNombreSexo.Click
        FSepararApellidoNombre.ShowDialog()

    End Sub

    Private Sub btnPaso4_EditarCUIL_SA_Antiguedad_Click(sender As Object, e As EventArgs) Handles btnPaso4_EditarCUIL_SA_Antiguedad.Click

        Call EliminarCambios()
        'si el adherente es ACTULIAZADO, edita el documento, halla el CUIL
        'toma el valor de la SAOriginal, calcula la edad y la antiguedad
        'calcula SA (para LCT y Luz y fuerza). 
        'Veririca que la SA no sea superior ni inferior a las permitidas y registra los cambios (tambien para optativo9
        ' anota los cambios de aumento de suma en cambios
        ' anota en observaciones de adherentes
        If FuncionEnProceso <> "Bajas" Then
            Call Procesar_Documento_Edades_SA_CUIL()
            'verifica que la edad no sea superior ni inferior a permitida y tambien a permanencia.
            'anota los cambios y en observaciones
            Call ControlarYAjustarEdad()

            If TipoContrato = "Obligaciones Laborales" And FuncionEnProceso <> "Bajas" Then
                Call AjustarSueldo()
            End If

        Else
            MsgBox("Proceso Terminado. Pasar al siguiente botón", MsgBoxStyle.Critical, "OPERACION EXITOSA")
        End If

    End Sub

    Private Sub btnPaso5_PrepararExcel_Click(sender As Object, e As EventArgs) Handles btnPaso5_PrepararExcel.Click

        ' recorre la tabla adherente buscando el documento de los adherentes Actualizados
        ' luego UPDATE de aquel registro cuyo CUIL like DOCUMENTO, marca como "ELIMINAR" en accion
        Select Case FuncionEnProceso
            Case "Bajas"
                BusquedaGrid = "Bajas"
                Call Bajas_RecuperaDocumentoADarDeBaja()
            Case "Altas"
                BusquedaGrid = "Altas"
                Call Altas_VerificarDuplicado()
            Case "Actualizar"
                BusquedaGrid = "Actualizar"
                Call Actualizado_BuscarDocumento()
                'en accion Eliminar aquellos vigentes que no han sido marcado por encontrado documento en el listado actualizado
                Call Actualizado_Eliminar()
        End Select

        Call Adherentes_ListarGrid()
    End Sub


    Sub Adherentes_ListarGrid()
        DataGridBusquedas.DataSource = Nothing
        DataGridBusquedas.Rows.Clear()

        Select Case BusquedaGrid
            Case "Bajas"
                ConsultaSQL = "Select id,Apellido,Nombre,CUIL,Accion from Adherentes where Accion='Eliminar' order by Apellido,Nombre"
            Case "Altas"
                ConsultaSQL = "Select id,Apellido,Nombre,CUIL,Accion from Adherentes where Accion='Agregar' order by Apellido,Nombre"
            Case "Repetidos"
                ConsultaSQL = "Select id,Apellido,Nombre,CUIL,Accion from Adherentes where Accion='Repetido' order by Apellido,Nombre"
            Case "Actualizar"
                ConsultaSQL = "Select id,Apellido,Nombre,CUIL,Accion from Adherentes where Accion='Agregar' or Marcado='1' order by Apellido,Nombre"
            Case "Actualizado"
                ConsultaSQL = "Select id,APELLIDO, NOMBRE, CUIL, ACCION From Adherentes"
                ConsultaSQL += " Where ORIGEN = 'Vigentes' And ACCION Is Null Or ORIGEN = 'Actualizado' And ACCION = 'Agregar'"
                ConsultaSQL += " Order By APELLIDO, NOMBRE"
            Case "Completo"
                ConsultaSQL = "Select id,APELLIDO, NOMBRE, CUIL, ACCION From Adherentes"
                ConsultaSQL += " Where ORIGEN = 'Vigentes' Or ORIGEN = 'Actualizado' And ACCION = 'Agregar'"
                ConsultaSQL += " Order By APELLIDO, NOMBRE"
        End Select

        Call LlenarGridBusqueda()

    End Sub
    Sub LlenarGridBusqueda()
        Try

            Dim Ds As New DataSet
            Dim Dt As New System.Data.DataTable


            Dim Adaptador As New OleDb.OleDbDataAdapter(ConsultaSQL, CONN)

            Ds.Tables.Add("Tabla")
            Adaptador.Fill(Ds.Tables("Tabla"))
            Me.DataGridBusquedas.DataSource = Ds.Tables("Tabla")



            REM Me.DataGridBusquedas.Columns(0).HeaderText = "Riesgos"
            REM Me.DataGridBusquedas.Columns(0).HeaderText = "Suma Asegurada"
            Me.DataGridBusquedas.Columns(0).Width = 1
            Me.DataGridBusquedas.Columns(1).Width = 100
            Me.DataGridBusquedas.Columns(2).Width = 150
            Me.DataGridBusquedas.Columns(3).Width = 80

        Catch ex As Exception

        End Try
    End Sub

    Private Sub VerRepetidosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VerRepetidosToolStripMenuItem.Click
        BusquedaGrid = "Repetidos"
        Call Adherentes_ListarGrid()
    End Sub

    Private Sub VerEliminadosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VerEliminadosToolStripMenuItem.Click
        BusquedaGrid = "Bajas"
        Call Adherentes_ListarGrid()
    End Sub

    Private Sub VerAgregadosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VerAgregadosToolStripMenuItem.Click
        BusquedaGrid = "Altas"
        Call Adherentes_ListarGrid()
    End Sub

    Private Sub VerListadoActualizadoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VerListadoActualizadoToolStripMenuItem.Click
        BusquedaGrid = "Actualizado"
        Call Adherentes_ListarGrid()
    End Sub

    Private Sub btnPaso6_ExportarAExcel_Click(sender As Object, e As EventArgs) Handles btnPaso6_ExportarAExcel.Click
        Mensaje = "Primero se volcará a archivo excel el listado de cambios realizados por adherente"
        MsgBox(Mensaje, MsgBoxStyle.Information, "ARMADO DE EXCEL CON LISTADO DE CAMBIOS")
        Call ExportarAExcelCambios()
        MsgBox("Ahora se armará el archivo Excel para Importar en Policy", MsgBoxStyle.Information, "ARMADO DE EXCEL PARA IMPORTAR")

        'Call ExportarAExcel()
        Call ExportarAExcelUsandoPlantilla()
    End Sub

    Private Sub VerListadoCompletoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VerListadoCompletoToolStripMenuItem.Click
        BusquedaGrid = "Completo"
        Call Adherentes_ListarGrid()
    End Sub


End Class
