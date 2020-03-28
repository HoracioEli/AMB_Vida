Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports System.IO
Module ModuloExcel
    Public MyExcel As Workbook
    Public ApExcel As Excel.Application
    Public HojaExcel As Worksheet
    Public Fila As Integer
    Public Columna As Integer
    Public Dato As String
    Public ArchivoPlantilla As String

    Sub VolcarEnTablaVigentes()

        Try
            'PRIMERO VACIA LA TABLA DATOS Vigentes

            Call EliminarVigentesActual()


            ApExcel = New Excel.Application()
            ApExcel.Visible = False
            MyExcel = ApExcel.Workbooks.Open(RutaPlantillaExcel,, False)

            Fila = 2
            Columna = 2

            Call LimpiarVariablesRow()

            IdPolicy = MyExcel.Sheets(1).Cells(Fila, Columna).Value


            While IdPolicy <> ""

                Columna = 4
                CUIL = MyExcel.Sheets(1).Cells(Fila, Columna).Value

                Columna = 5
                APELLIDO = MyExcel.Sheets(1).Cells(Fila, Columna).Value

                Columna = 6
                NOMBRE = MyExcel.Sheets(1).Cells(Fila, Columna).Value

                Columna = 7
                SEXO = MyExcel.Sheets(1).Cells(Fila, Columna).Value

                Columna = 8
                FNACIMIENTO = MyExcel.Sheets(1).Cells(Fila, Columna).Value

                Columna = 9
                GRUPO = MyExcel.Sheets(1).Cells(Fila, Columna).Value

                If FPrincipal.CboTipoContrato.Text <> "Obligaciones Laborales" Then
                    Columna = 10
                    SUMAASEGURADA = MyExcel.Sheets(1).Cells(Fila, Columna).Value
                Else
                    Columna = 10
                    SUELDO = MyExcel.Sheets(1).Cells(Fila, Columna).Value
                End If

                If FPrincipal.CboTipoContrato.Text <> "Obligaciones Laborales" Then
                    Columna = 11
                    BENEFICIARIO = MyExcel.Sheets(1).Cells(Fila, Columna).Value
                Else
                    Columna = 11
                    FINGRESO = MyExcel.Sheets(1).Cells(Fila, Columna).Value
                End If


                If FPrincipal.CboTipoContrato.Text = "Obligaciones Laborales" Then
                    Columna = 12
                    SUMAASEGURADA = MyExcel.Sheets(1).Cells(Fila, Columna).Value
                End If


                If FPrincipal.CboTipoContrato.Text = "Obligaciones Laborales" Then
                    Columna = 13
                    BENEFICIARIO = MyExcel.Sheets(1).Cells(Fila, Columna).Value
                End If

                If IdPolicy <> Nothing Then
                    Call IngresarVigentes()
                    FPrincipal.Text = "Procesando el registro " & Contador & " " & APELLIDO & " " & NOMBRE
                    Call LimpiarVariablesRow()
                    Contador = Contador + 1
                End If

                Columna = 2
                Fila = Fila + 1

                IdPolicy = MyExcel.Sheets(1).Cells(Fila, Columna).Value
            End While
            FPrincipal.Text = "Movimientos en Vida Colectivo en POLICY"
            MyExcel.Close()
            ApExcel.Quit()

            MsgBox("Se han importado en forma exitosa " & Contador & " registros", MsgBoxStyle.Information, "IMPORTACION EXITOSA")


        Catch ex As Exception
            MyExcel.Close()
            ApExcel.Quit()
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub AbrirPlantillaExcel()
        Dim MyExcel As Workbook
        Dim ApExcel As Excel.Application

        Dim RutaPlantilla As String = RutaLocal & ArchivoPlantilla

        ApExcel = New Excel.Application()
        ApExcel.Visible = True
        MyExcel = ApExcel.Workbooks.Open(RutaPlantilla)
    End Sub
    Sub Paso2_VolcarEnTablaActualizados()


        'el archivo plantilla depende si se trata de bajas o de altas-actualizado
        RutaPlantilla = RutaLocal & ArchivoPlantilla

        Dim Contador As Integer

        'PRIMERO VACIA LA TABLA DATOS ACTUALIZADOS
        Call EliminarActualizado()

        ApExcel = New Excel.Application()
        ApExcel.Visible = False
        MyExcel = ApExcel.Workbooks.Open(RutaPlantilla,, False)

        Try
            Fila = 2
            Columna = 1
            'vuelve todas las variables asociadas a las tablas a nothing
            Call LimpiarVariablesRow()

            APELLIDO = MyExcel.Sheets(1).Cells(Fila, Columna).Value
            APELLIDO = APELLIDO.ToUpper
            Contador = 0
            While APELLIDO <> ""
                Contador = Contador + 1
                Columna = 2
                NOMBRE = MyExcel.Sheets(1).Cells(Fila, Columna).Value
                ' NOMBRE = NOMBRE.ToUpper
                ' NOMBRE = Trim(NOMBRE)

                Columna = 3
                Documento = MyExcel.Sheets(1).Cells(Fila, Columna).Value

                If FuncionEnProceso <> "Bajas" Then
                    Columna = 4
                    FNACIMIENTO = MyExcel.Sheets(1).Cells(Fila, Columna).Value

                    Columna = 5
                    FINGRESO = MyExcel.Sheets(1).Cells(Fila, Columna).Value

                    Columna = 6
                    SUELDO = MyExcel.Sheets(1).Cells(Fila, Columna).Value

                    Columna = 7
                    SUMAASEGURADA = MyExcel.Sheets(1).Cells(Fila, Columna).Value
                End If

                'chequea que los valores de excel sean correctos, sino avisa y suspenda la carga
                Call ControlarLecturaPlantillaExcel()

                If Controlado = 0 Then
                    Exit While
                End If
                Call IngresarActualizado()
                'vuelve todas las variables asocidas a las tablas a nothing
                FPrincipal.Text = "Procesando el registro " & Contador & " - " & APELLIDO & " " & NOMBRE
                Call LimpiarVariablesRow()

                Fila = Fila + 1
                Columna = 1
                APELLIDO = MyExcel.Sheets(1).Cells(Fila, Columna).Value
                APELLIDO = Trim(APELLIDO)
                APELLIDO = APELLIDO.ToUpper

            End While
            FPrincipal.Text = "Movimientos de VIDA COLECTIVO en POLICY"
            MyExcel.Close()
            ApExcel.Quit()

            If Controlado = 1 Then
                MsgBox("Se han importado en forma exitosa " & Contador & " contador", MsgBoxStyle.Information, "IMPORTACION EXITOSA")
            End If

        Catch ex As Exception
            MyExcel.Close()
            ApExcel.Quit()
            MsgBox(ex.Message)



        End Try

    End Sub
    Sub ControlarLecturaPlantillaExcel()
        Controlado = 0

        'en las bajas solo chequea que este el nro de documento
        ' If Documento = Nothing Then
        'Mensaje = "Falta indicar el documento de " & APELLIDO & " " & NOMBRE
        'MsgBox(Mensaje, MsgBoxStyle.Critical, "PROCESO ABORTADO DEBE CONTROLAR LOS DATOS DE LA PLANTILLA EXCEL")
        'Exit Sub
        'End If

        'en el caso que sea alta, tengo que revisar ademàs la fecha de nacimiento y otros datos
        'dependiendo el tipo de  contrato

        If FuncionEnProceso <> "Bajas" Then
            If IsDate(FNACIMIENTO) = False Then
                Mensaje = "La fecha de nacimiento de " & APELLIDO & " " & NOMBRE & " no es válida"
                MsgBox(Mensaje, MsgBoxStyle.Critical, "PROCESO ABORTADO DEBE CONTROLAR LOS DATOS DE LA PLANTILLA EXCEL")
                Exit Sub
            Else
                FNACIMIENTO = Format(CDate(FNACIMIENTO), "Short Date")
            End If


            Select Case TipoContrato
                Case "Obligaciones Laborales", "Luz y Fuerza"
                    If IsDate(FINGRESO) = False Then
                        Mensaje = "La fecha de ingreso de " & APELLIDO & " " & NOMBRE & " no es válida"
                        MsgBox(Mensaje, MsgBoxStyle.Critical, "PROCESO ABORTADO DEBE CONTROLAR LOS DATOS DE LA PLANTILLA EXCEL")
                        Exit Sub
                    Else
                        FINGRESO = Format(CDate(FINGRESO), "Short Date")
                    End If

                    If IsNumeric(SUELDO) = False Then
                        Mensaje = "El sueldo de " & APELLIDO & " " & NOMBRE & " no es válido"
                        MsgBox(Mensaje, MsgBoxStyle.Critical, "PROCESO ABORTADO DEBE CONTROLAR LOS DATOS DE LA PLANTILLA EXCEL")
                        Exit Sub
                    End If

                Case "Optativo"
                    If IsNumeric(SUMAASEGURADA) = False Then
                        Mensaje = "La Suma Asegurada de " & APELLIDO & " " & NOMBRE & " no es válido"
                        MsgBox(Mensaje, MsgBoxStyle.Critical, "PROCESO ABORTADO DEBE CONTROLAR LOS DATOS DE LA PLANTILLA EXCEL")
                        Exit Sub
                    End If

                Case Else
                    SUMAASEGURADA = "0"
                    SUELDO = "0"
            End Select
        End If

        Controlado = 1

    End Sub

    Sub ExportarAExcel()
        Dim Archivo As String
        Try
            ApExcel = New Excel.Application()
            ApExcel.Visible = False

            If TipoContrato = "Obligaciones Laborales" Then
                MyExcel = ApExcel.Workbooks.Open(RutaLocal & "PlantillaLCT.xlsx")
            Else
                MyExcel = ApExcel.Workbooks.Open(RutaLocal & "PlantillaOtros.xlsx")

            End If
            Select Case FuncionEnProceso
                Case "Bajas"
                    ConsultaSQL = "Select ACCION,IDPOLICY,CUIL,APELLIDO,NOMBRE,SEXO,FNACIMIENTO,SUELDO,FINGRESO,SUMAASEGURADA,BENEFICIARIO from adherentes"
                    ConsultaSQL += " Where Origen='Vigentes' ORDER BY APELLIDO"
                Case "Altas", "Actualizar"
                    ConsultaSQL = "Select ACCION,IDPOLICY,CUIL,APELLIDO,NOMBRE,SEXO,FNACIMIENTO,SUELDO,FINGRESO,SUMAASEGURADA,BENEFICIARIO from adherentes"
                    ConsultaSQL += " Where Origen='Vigentes' or Origen='Actualizado' and Accion='Agregar' ORDER BY APELLIDO"
                Case Else
                    MsgBox("Operación no concretada", MsgBoxStyle.Exclamation, "OPERACION ABORTADA")
                    MyExcel.Close()
                    ApExcel.Quit()
                    dr2.Close()
                    Exit Sub
            End Select

            Fila = 2
            Contador = 0
            Call Consultar2()
            If dr2.HasRows Then
                While dr2.Read()
                    Contador += 1
                    Accion = dr2(0).ToString
                    IdPolicy = dr2(1).ToString
                    CUIL = dr2(2).ToString
                    APELLIDO = dr2(3).ToString
                    NOMBRE = dr2(4).ToString
                    SEXO = dr2(5).ToString
                    FNACIMIENTO = dr2(6).ToString
                    FNACIMIENTO = CStr(Format(CDate(FNACIMIENTO), "Short Date"))
                    SUELDO = dr2(7).ToString
                    FINGRESO = dr2(8).ToString
                    If IsDate(FINGRESO) Then
                        FINGRESO = CStr(Format(CDate(FINGRESO), "Short Date"))
                    End If

                    SUMAASEGURADA = dr2(9).ToString
                    BENEFICIARIO = dr2(10).ToString

                    If BENEFICIARIO = Nothing Then
                        BENEFICIARIO = "Tomador"
                    End If

                    MyExcel.Sheets(1).Cells(Fila, 1).Value = Accion
                    MyExcel.Sheets(1).Cells(Fila, 2).Value = IdPolicy
                    MyExcel.Sheets(1).Cells(Fila, 3).Value = "C.U.I.L."
                    MyExcel.Sheets(1).Cells(Fila, 4).Value = CUIL
                    MyExcel.Sheets(1).Cells(Fila, 5).Value = APELLIDO
                    MyExcel.Sheets(1).Cells(Fila, 6).Value = NOMBRE
                    MyExcel.Sheets(1).Cells(Fila, 7).Value = SEXO
                    MyExcel.Sheets(1).Cells(Fila, 8).Value = FNACIMIENTO

                    Select Case FPrincipal.CboTipoContrato.Text
                        Case "Obligaciones Laborales"
                            MyExcel.Sheets(1).Cells(Fila, 10).Value = CSng(Format(CSng(SUELDO), "####.00"))
                            MyExcel.Sheets(1).Cells(Fila, 11).Value = FINGRESO
                            MyExcel.Sheets(1).Cells(Fila, 12).Value = SUMAASEGURADA
                            MyExcel.Sheets(1).Cells(Fila, 13).Value = BENEFICIARIO
                        Case Else
                            MyExcel.Sheets(1).Cells(Fila, 10).Value = SUMAASEGURADA
                            MyExcel.Sheets(1).Cells(Fila, 11).Value = BENEFICIARIO
                    End Select


                    Fila = Fila + 1
                    FPrincipal.Text = "Procesando registro: " & Contador & " - " & APELLIDO & " " & NOMBRE
                End While
            End If

            Archivo = "C:\Publico\" & "ParaImportarAPolicy.xlsx"

            If File.Exists(Archivo) Then
                My.Computer.FileSystem.DeleteFile(Archivo)
            End If

            MyExcel.SaveAs(Archivo)
            ApExcel.Quit()

            MsgBox("Próximo paso desde POLICY importar el archivo 'ParaImportarAPolicy' ubicado en c:\publico", MsgBoxStyle.Information, "PROCESO TERMINADO")


            dr2.Close()
        Catch ex As Exception
            dr2.Close()
            MsgBox(ex.Message)
        End Try


    End Sub



    Sub ExportarAExcelCambios()
        Dim Archivo As String
        Dim ApellidoNombreAnterior As String = Nothing
        Try
            ApExcel = New Excel.Application()
            ApExcel.Visible = False


            MyExcel = ApExcel.Workbooks.Open(RutaLocal & "Cambios.xlsx")


            ConsultaSQL = "Select Id,ApellidoNombre,CONCEPTO,VIGENTE,ACTUALIZADO from Cambios"
            ConsultaSQL += " ORDER BY ApellidoNombre"



            Fila = 2
            Contador = 0
            Call Consultar2()
            If dr2.HasRows Then
                While dr2.Read()
                    Contador += 1
                    IdAdherente = CInt(dr2(0).ToString)
                    ApellidoNombre = dr2(1).ToString
                    Concepto = dr2(2).ToString
                    Vigente = dr2(3).ToString
                    Actualizado = dr2(4).ToString

                    If ApellidoNombreAnterior <> ApellidoNombre Then
                        MyExcel.Sheets(1).Cells(Fila, 1).Value = ApellidoNombre
                    End If
                    ApellidoNombreAnterior = ApellidoNombre
                    MyExcel.Sheets(1).Cells(Fila, 2).Value = Concepto
                    MyExcel.Sheets(1).Cells(Fila, 3).Value = Vigente
                    MyExcel.Sheets(1).Cells(Fila, 4).Value = Actualizado

                    Fila = Fila + 1
                    FPrincipal.Text = "Procesando registro: " & Contador
                End While
            End If

            Archivo = "C:\Publico\" & "Registro de Cambios.xlsx"

            If File.Exists(Archivo) Then
                My.Computer.FileSystem.DeleteFile(Archivo)
            End If

            MyExcel.SaveAs(Archivo)
            ApExcel.Quit()




            dr2.Close()
        Catch ex As Exception
            dr2.Close()
            MsgBox(ex.Message)
        End Try


    End Sub



    Sub ExportarAExcelUsandoPlantilla()

        Try
            ApExcel = New Excel.Application()
            ApExcel.Visible = False

            MyExcel = ApExcel.Workbooks.Open(FPrincipal.LbRutaPlantillaExcel.Text)
            Contador = 0

            Fila = 2
            Columna = 2


            IdPolicy = MyExcel.Sheets(1).Cells(Fila, Columna).Value

            While IdPolicy <> Nothing
                Columna = 2
                IdPolicy = MyExcel.Sheets(1).Cells(Fila, Columna).Value
                ConsultaSQL = "Select IdPolicy,APELLIDO,NOMBRE,CUIL,SEXO,FNACIMIENTO,SUMAASEGURADA,FINGRESO,SUELDO,ACCION from Adherentes"
                ConsultaSQL += " where IdPolicy ='" & IdPolicy & "'"
                Call Consultar()
                If dr.HasRows Then
                    While dr.Read()
                        APELLIDO = dr(1).ToString
                        NOMBRE = dr(2).ToString
                        CUIL = dr(3).ToString
                        SEXO = dr(4).ToString
                        FNACIMIENTO = dr(5).ToString
                        SUMAASEGURADA = dr(6).ToString
                        FINGRESO = dr(7).ToString
                        SUELDO = dr(8).ToString
                        Accion = dr(9).ToString
                    End While

                    MyExcel.Sheets(1).Cells(Fila, 1).Value = Accion
                    'MyExcel.Sheets(1).Cells(Fila, 2).Value = IdPolicy
                    MyExcel.Sheets(1).Cells(Fila, 3).Value = "C.U.I.L."
                    MyExcel.Sheets(1).Cells(Fila, 4).Value = CUIL
                    MyExcel.Sheets(1).Cells(Fila, 5).Value = APELLIDO
                    MyExcel.Sheets(1).Cells(Fila, 6).Value = NOMBRE
                    MyExcel.Sheets(1).Cells(Fila, 7).Value = SEXO
                    MyExcel.Sheets(1).Cells(Fila, 8).Value = FNACIMIENTO

                    Select Case FPrincipal.CboTipoContrato.Text
                        Case "Obligaciones Laborales"
                            MyExcel.Sheets(1).Cells(Fila, 10).Value = CSng(Format(CSng(SUELDO), "####,00"))
                            MyExcel.Sheets(1).Cells(Fila, 11).Value = FINGRESO
                            '   MyExcel.Sheets(1).Cells(Fila, 12).Value = SUMAASEGURADA
                            MyExcel.Sheets(1).Cells(Fila, 13).Value = "Tomador"
                        Case Else
                            MyExcel.Sheets(1).Cells(Fila, 10).Value = SUMAASEGURADA
                            MyExcel.Sheets(1).Cells(Fila, 11).Value = "Tomador"
                    End Select

                    Contador = Contador + 1
                    Fila = Fila + 1
                    FPrincipal.Text = "Procesando registro: " & Contador & " - " & APELLIDO & " " & NOMBRE
                    dr.Close()
                Else
                    dr.Close()
                End If


            End While

            ' MyExcel.Save()
            'ApExcel.Quit()

            MsgBox("Se actualizó el listado Vigente. Proximo Paso, agregar los nuevos", MsgBoxStyle.Information, "PROCESO TERMINADO")


            Call ExportarAExcelAgregarNuevos()

        Catch ex As Exception
            ' MyExcel.Close()
            ApExcel.Quit()
            If dr.IsClosed = False Then
                dr.Close()
            End If
            MsgBox(ex.Message)
        End Try


    End Sub


    Sub ExportarAExcelAgregarNuevos()

        Try
            Contador = 0
            ConsultaSQL = "Select APELLIDO,NOMBRE,CUIL,SEXO,FNACIMIENTO,SUMAASEGURADA,FINGRESO,SUELDO,ACCION from Adherentes"
            ConsultaSQL += " where ACCION ='Agregar'"
            Call Consultar()
            If dr.HasRows Then
                While dr.Read()
                    APELLIDO = dr(0).ToString
                    NOMBRE = dr(1).ToString
                    CUIL = dr(2).ToString
                    SEXO = dr(3).ToString
                    FNACIMIENTO = dr(4).ToString
                    SUMAASEGURADA = dr(5).ToString
                    FINGRESO = dr(6).ToString
                    SUELDO = dr(7).ToString
                    Accion = dr(8).ToString


                    MyExcel.Sheets(1).Cells(Fila, 1).Value = Accion
                    'MyExcel.Sheets(1).Cells(Fila, 2).Value = IdPolicy
                    MyExcel.Sheets(1).Cells(Fila, 3).Value = "C.U.I.L."
                    MyExcel.Sheets(1).Cells(Fila, 4).Value = CUIL
                    MyExcel.Sheets(1).Cells(Fila, 5).Value = APELLIDO
                    MyExcel.Sheets(1).Cells(Fila, 6).Value = NOMBRE
                    MyExcel.Sheets(1).Cells(Fila, 7).Value = SEXO
                    MyExcel.Sheets(1).Cells(Fila, 8).Value = FNACIMIENTO

                    Select Case FPrincipal.CboTipoContrato.Text
                        Case "Obligaciones Laborales"
                            MyExcel.Sheets(1).Cells(Fila, 10).Value = CSng(Format(CSng(SUELDO), "####,00"))
                            MyExcel.Sheets(1).Cells(Fila, 11).Value = FINGRESO
                            '   MyExcel.Sheets(1).Cells(Fila, 12).Value = SUMAASEGURADA
                            MyExcel.Sheets(1).Cells(Fila, 13).Value = "Tomador"
                        Case Else
                            MyExcel.Sheets(1).Cells(Fila, 10).Value = SUMAASEGURADA
                            MyExcel.Sheets(1).Cells(Fila, 11).Value = "Tomador"
                    End Select

                    Contador = Contador + 1
                    Fila = Fila + 1
                    FPrincipal.Text = "Procesando registro: " & Contador & " - " & APELLIDO & " " & NOMBRE
                End While

            End If
            dr.Close()
            MyExcel.Save()
            ApExcel.Quit()

            MsgBox("Se agregaron el/los " & Contador & " nuevo/s. Ahora hay que migrar el archivo descargado de Policy recientemente actualizado", MsgBoxStyle.Information, "PROCESO TERMINADO")

        Catch ex As Exception

            MyExcel.Close()
            ApExcel.Quit()
            If dr.IsClosed = False Then
                dr.Close()
            End If
            MsgBox(ex.Message)
        End Try


    End Sub

End Module
