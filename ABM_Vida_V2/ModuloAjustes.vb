Module ModuloAjustes
    Public DocumentoAProcesar As String
    Public SAOriginal, SAAjustada As String
    Public Observaciones, ExcluidoPorEdad As String




    Sub Procesar_Documento_Edades_SA_CUIL()

        Try
            ConsultaSQL = "SELECT Id,Documento, Apellido, Nombre, FNacimiento,FIngreso, Sueldo, Sexo,Origen, SumaAsegurada"
            ConsultaSQL += " From Adherentes"

            DocumentoAProcesar = Nothing

            Call Consultar2()
            If dr2.HasRows Then
                While dr2.Read()
                    Contador += 1
                    IdAdherente = CInt(dr2(0).ToString)
                    DocumentoAProcesar = dr2(1).ToString
                    APELLIDO = dr2(2).ToString
                    NOMBRE = dr2(3).ToString
                    FNACIMIENTO = dr2(4).ToString
                    FINGRESO = dr2(5).ToString
                    If dr2(6).ToString <> Nothing Then
                        SUELDO = CStr(CSng(dr2(6).ToString))
                    Else
                        SUELDO = "0"
                    End If

                    SEXO = dr2(7).ToString
                    Origen = dr2(8).ToString

                    If Origen = "Actualizado" Then
                        Call DejarSolo8Digitos()
                        Call HallarCuil()
                    End If
                    SAOriginal = dr2(9).ToString



                    Call CalcularEdades()

                    Select Case TipoContrato
                        Case "Luz y Fuerza", "Obligaciones Laborales"
                            Call CalcularAntiguedad()
                            Call CalcularSAxAntiguedad()
                    End Select
                    If Controlado = 0 Then
                        dr2.Close()
                        Exit Sub
                    End If
                    FPrincipal.Text = "Procesando el registro " & Contador & " - " & APELLIDO & " " & NOMBRE
                End While
            End If
            FPrincipal.Text = "Movimientos Vida Colectivo Policy"

            MsgBox("Proceso terminado. Continuar con el siguiente paso", MsgBoxStyle.Information, "PROCESO TERMINADO")
            dr2.Close()
        Catch ex As Exception
            dr2.Close()
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub DejarSolo8Digitos()
        Controlado = 0

        'buscar y elimina "," "." ";" y hasta espacio

        DocumentoAProcesar = Replace(DocumentoAProcesar, ".", "")
        DocumentoAProcesar = Replace(DocumentoAProcesar, ",", "")
        DocumentoAProcesar = Replace(DocumentoAProcesar, ";", "")
        DocumentoAProcesar = Replace(DocumentoAProcesar, "'", "")
        DocumentoAProcesar = Replace(DocumentoAProcesar, " ", "")
        DocumentoAProcesar = Replace(DocumentoAProcesar, "-", "")
        DocumentoAProcesar = Replace(DocumentoAProcesar, "/", "")

        If IsNumeric(DocumentoAProcesar) = False Then
            MsgBox("Revisar el Nro de CUIL o DOCUMENTO de " & APELLIDO & " " & NOMBRE & Chr(10) & "Tiene caracteres no esperados", MsgBoxStyle.Critical, "REQUIERE PARTICIPACION DEL OPERADOR PARA CONTROLAR DATOS ACTUALIZADOS")
            Exit Sub
        End If


        'le saco los espacios al principio y al final
        DocumentoAProcesar = Trim(DocumentoAProcesar)

        'si el documento viene en forma de CUIL, deja solo la parte del documento
        If Len(DocumentoAProcesar) = 11 Then
            DocumentoAProcesar = DocumentoAProcesar.Substring(2) ' saca los dos primeros digitos 
            DocumentoAProcesar = DocumentoAProcesar.Substring(0, 8) 'saca  el digito control
        End If

        If Len(DocumentoAProcesar) = 7 Then 'significa que es un documento viejo, ejemplo: 5.450.320
            DocumentoAProcesar = "0" & DocumentoAProcesar
        ElseIf Len(DocumentoAProcesar) < 7 Then
            MsgBox("Revisar el Nro de CUIL o DOCUMENTO de " & APELLIDO & " " & NOMBRE & Chr(10) & "POSIBLE ERROR EN NRO DE DOCUMENTO", MsgBoxStyle.Critical, "REQUIERE PARTICIPACION DEL OPERADOR PARA CONTROLAR DATOS ACTUALIZADOS")
            Exit Sub
        End If


        Controlado = 1



    End Sub
    Sub CalcularEdades()

        Dim FechaNacimientoParaCalcularEdad As Date
        Dim Mensaje As String
        Dim diaFN, mesFN As String
        Dim diaT, mesT As String


        Try
            Controlado = 0
            If IsDate(CDate(FNACIMIENTO)) = False Or FNACIMIENTO = Nothing Then
                Mensaje = "La fecha de nacimiento de: " & Chr(10) & APELLIDO & " " & NOMBRE & Chr(10)
                Mensaje += "no tiene el formato adecuado o falta" & Chr(10)
                Mensaje += "Deberá corregirse para poder continuar"

                MsgBox(Mensaje, MsgBoxStyle.Critical, "ERROR EN LOS DATOS EN EL LISTADO ACTUALIZADOS")
                Exit Sub
            End If

            FechaNacimientoParaCalcularEdad = CDate(FNACIMIENTO)


            diaFN = FechaNacimientoParaCalcularEdad.Day
            mesFN = FechaNacimientoParaCalcularEdad.Month
            diaT = Today.Day
            mesT = Today.Month




            Edad = DateDiff(DateInterval.Year, FechaNacimientoParaCalcularEdad, Today())
            If CByte(mesT) < CByte(mesFN) Then
                Edad = CInt(Edad) - 1
            End If

            If mesT = mesFN Then
                If CByte(diaT) < CByte(diaFN) Then
                    Edad = CInt(Edad) - 1
                End If
            End If

            Call AgregarEdad_Tabla_Adherentes()

            Controlado = 1


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Sub CalcularAntiguedad()
        Dim FechaIngresoParaCalcularAntiguedad As Date

        Dim diaFI, mesFI As String
        Dim diaT, mesT As String
        Dim Mensaje As String
        Dim MesesSobrantes As Integer
        Dim MesesAntiguedad As Integer

        Try

            Controlado = 0
            If IsDate(FINGRESO) = False Or FINGRESO = Nothing Then
                Mensaje = "La fecha de ingreso de: " & Chr(10) & APELLIDO & " " & NOMBRE & Chr(10)
                Mensaje += "no tiene el formato adecuado o falta" & Chr(10)
                Mensaje += "Deberá corregirse para poder continuar"

                MsgBox(Mensaje, MsgBoxStyle.Critical, "ERROR EN LOS DATOS EN EL LISTADO ACTUALIZADOS")
                Exit Sub
            End If

            FechaIngresoParaCalcularAntiguedad = CDate(FINGRESO)


            diaFI = FechaIngresoParaCalcularAntiguedad.Day
            mesFI = FechaIngresoParaCalcularAntiguedad.Month

            diaT = Today.Day
            mesT = Today.Month


            MesesAntiguedad = DateDiff(DateInterval.Month, FechaIngresoParaCalcularAntiguedad, Today())


            MesesSobrantes = MesesAntiguedad Mod 12
            AnosAntiguedad = MesesAntiguedad / 12
            If MesesSobrantes > 3 Then
                AnosAntiguedad += 1
            End If

            If AnosAntiguedad < 2 Then
                AnosAntiguedad = 2
            End If
            Call AgregarAntiguedad_Tabla_Adherentes()
            Controlado = 1

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Sub CalcularSAxAntiguedad()
        Dim SueldoParaCalcular As Single
        Dim Mensaje As String
        Dim AjusteAntiguedad As Single
        Try
            Controlado = 0

            If IsNumeric(CSng(SUELDO)) = False Or SUELDO = Nothing Then
                Mensaje = "El sueldo de: " & Chr(10) & APELLIDO & " " & NOMBRE & Chr(10)
                Mensaje += "no tiene el formato adecuado o falta" & Chr(10)
                Mensaje += "Deberá corregirse para poder continuar"

                MsgBox(Mensaje, MsgBoxStyle.Critical, "ERROR EN LOS DATOS EN EL LISTADO ACTUALIZADOS")
                Exit Sub
            End If


            SueldoParaCalcular = CSng(SUELDO)

            If FPrincipal.CboTipoContrato.Text = "Obligaciones Laborales" Then
                SUMAASEGURADA = CStr((AnosAntiguedad * SueldoParaCalcular) / 2)
                SUMAASEGURADA = Format(CSng(SUMAASEGURADA), "####")
                Call ControlarSAEntreMinimaYMaxima()
                'el valor de suma asegurada pueda cambiar al valor de sa maxima o minima, si es que la calculada
                'supera a la maxima y esta por debajo de la minima

                If Origen = "Vigentes" Then
                    If CInt(SAOriginal) <> CInt(SUMAASEGURADA) Then
                        ApellidoNombre = APELLIDO & " " & NOMBRE
                        If SAAjustada = Nothing Then
                            Concepto = "Cambio en Suma Asegurada"
                            Vigente = CSng(CInt(SAOriginal))
                            Actualizado = SUMAASEGURADA
                            Observaciones = "SA Modificada"
                        Else
                            If SAAjustada = SAMinima Then
                                Concepto = "SA ajustada a Minima"
                            ElseIf saajustada = samaxima Then
                                Concepto = "SA ajustada a Maxima"
                            End If

                            Vigente = CSng(CInt(SAOriginal))
                                Actualizado = SAAjustada
                                Observaciones = "SA Topeada"
                            End If
                            Call IngresarEnCambios()
                    End If
                End If

            ElseIf FPrincipal.CboTipoContrato.Text = "Luz y Fuerza" Then

                SUMAASEGURADA = SueldoParaCalcular * 10
                AjusteAntiguedad = CSng(AnosAntiguedad)
                If AjusteAntiguedad > 5 Then
                    AjusteAntiguedad = AjusteAntiguedad - 5
                    AjusteAntiguedad = AjusteAntiguedad * 2
                    AjusteAntiguedad = 1 + (AjusteAntiguedad / 100)
                    SUMAASEGURADA = SUMAASEGURADA * AjusteAntiguedad
                    SUMAASEGURADA = Format(CSng(SUMAASEGURADA), "####")
                    Call ControlarSAEntreMinimaYMaxima()
                    'el valor de suma asegurada pueda cambiar al valor de sa maxima o minima, si es que la calculada
                    'supera a la maxima y esta por debajo de la minima

                    If Origen = "Vigentes" Then
                        If CInt(SAOriginal) <> CInt(SUMAASEGURADA) Then
                            ApellidoNombre = APELLIDO & " " & NOMBRE
                            If SAAjustada = Nothing Then
                                Concepto = "Cambio en Suma Asegurada"
                                Vigente = CSng(CInt(SAOriginal))
                                Actualizado = SUMAASEGURADA
                                Observaciones = "SA Modificada"
                            Else
                                If SAAjustada = SAMinima Then
                                    Concepto = "SA ajustada a Minima"
                                ElseIf SAAjustada = SAMaxima Then
                                    Concepto = "SA ajustada a Maxima"
                                End If
                                Vigente = CSng(CInt(SAOriginal))
                                Actualizado = SAAjustada
                                Observaciones = "SA Topeada"
                            End If
                            Call IngresarEnCambios()
                        End If
                    End If
                End If
            ElseIf FPrincipal.CboTipoContrato.Text = "Optativo" Then
                Call ControlarSAEntreMinimaYMaxima()
                'el valor de suma asegurada pueda cambiar al valor de sa maxima o minima, si es que la calculada
                'supera a la maxima y esta por debajo de la minima

                If Origen = "Vigentes" Then
                    If CInt(SAOriginal) <> CInt(SUMAASEGURADA) Then
                        ApellidoNombre = APELLIDO & " " & NOMBRE
                        If SAAjustada = Nothing Then
                            Concepto = "Cambio en Suma Asegurada"
                            Vigente = CSng(CInt(SAOriginal))
                            Actualizado = SUMAASEGURADA
                            Observaciones = "SA Modificada"
                        Else
                            If SAAjustada = SAMinima Then
                                Concepto = "SA ajustada a Minima"
                            ElseIf SAAjustada = SAMaxima Then
                                Concepto = "SA ajustada a Maxima"
                            End If
                            Vigente = CSng(CInt(SAOriginal))
                            Actualizado = SAAjustada
                            Observaciones = "SA Topeada"
                        End If
                        Call IngresarEnCambios()
                    End If
                End If

            End If

            Call AgregarSumaAsegurada_Tabla_adherentes()
            Call AgregarObservaciones_Tabla_Adherentes()
            Controlado = 1

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Sub HallarCuil()
        Try
            Dim X, Y As String
            Dim Z As String
            Dim Sumatoria As Integer
            Dim N1, N2, N3, N4, N5, N6, N7, N8 As String
            Dim Redondeo As Integer = 0
            Dim Resto As Integer

            Controlado = 0

            X = 2
            Select Case SEXO
                Case "Femenino"
                    Y = 7
                Case "Masculino"
                    Y = 0
            End Select

            N1 = Mid(DocumentoAProcesar, 1, 1)
            N2 = Mid(DocumentoAProcesar, 2, 1)
            N3 = Mid(DocumentoAProcesar, 3, 1)
            N4 = Mid(DocumentoAProcesar, 4, 1)
            N5 = Mid(DocumentoAProcesar, 5, 1)
            N6 = Mid(DocumentoAProcesar, 6, 1)
            N7 = Mid(DocumentoAProcesar, 7, 1)
            N8 = Mid(DocumentoAProcesar, 8, 1)

            Sumatoria = 0
            Sumatoria = CInt(X) * 5
            Sumatoria = Sumatoria + CInt(Y) * 4
            Sumatoria = Sumatoria + CInt(N1) * 3
            Sumatoria = Sumatoria + CInt(N2) * 2
            Sumatoria = Sumatoria + CInt(N3) * 7
            Sumatoria = Sumatoria + CInt(N4) * 6
            Sumatoria = Sumatoria + CInt(N5) * 5
            Sumatoria = Sumatoria + CInt(N6) * 4
            Sumatoria = Sumatoria + CInt(N7) * 3
            Sumatoria = Sumatoria + CInt(N8) * 2

            Redondeo = Int(Sumatoria / 11)

            Resto = Sumatoria - (Redondeo * 11)

            Select Case Resto
                Case 0
                    Z = 0
                Case 1
                    Y = 3
                    If SEXO = "Femenino" Then Z = 4
                    If SEXO = "Masculino" Then Z = 9
                Case Else
                    Z = CStr(Math.Abs(Resto - 11))
            End Select

            CUIL = X & Y & "-" & DocumentoAProcesar & "-" & Z

            Call AgregarCUIL_Tabla_Adherentes()

            Controlado = 1
        Catch ex As Exception
            Dim Mensaje As String

            Mensaje = "Existe algun problema con : " & Chr(10) & APELLIDO & " " & NOMBRE & Chr(10)
            Mensaje += "para convertir el documento a CUIL" & Chr(10)
            Mensaje += "Deberá corregirse para poder continuar"

            MsgBox(Mensaje, MsgBoxStyle.Critical, "ERROR EN LOS DATOS EN EL LISTADO ACTUALIZADOS")

        End Try

    End Sub




    Sub ControlarYAjustarEdad()

        Try

            ConsultaSQL = "SELECT Id, EDAD,ORIGEN,APELLIDO,NOMBRE, Observaciones "
            ConsultaSQL += " From adherentes"

            Call Consultar2()
            If dr2.HasRows Then
                While dr2.Read()

                    Edad = dr2(1).ToString
                    Origen = dr2(2).ToString
                    Observaciones = dr2(5).ToString

                    APELLIDO = dr2(3).ToString
                    NOMBRE = dr2(4).ToString
                    ApellidoNombre = APELLIDO & " " & NOMBRE
                    IdAdherente = CInt(dr2(0).ToString)


                    If Origen = "Vigentes" Then
                        If CInt(Edad) > CInt(EdadPermanencia) Then
                            Concepto = "Excede Edad Permanencia"
                            Vigente = Edad
                            Actualizado = EdadPermanencia
                            Call IngresarEnCambios()
                            ExcluidoPorEdad = "1"

                            If Observaciones = Nothing Then
                                Observaciones = "Supera Edad Permanencia"
                            Else
                                Observaciones = Observaciones & " - " & "Supera Edad Permanencia"
                            End If

                        End If
                    End If

                    If Origen = "Actualizado" Then
                        If CInt(Edad) < CInt(EdadMinima) Then
                            Concepto = "Edad menor a permitida"
                            Vigente = Edad
                            Actualizado = EdadMinima
                            Call IngresarEnCambios()

                            ExcluidoPorEdad = "1"

                            If Observaciones = Nothing Then
                                Observaciones = "Inferior Edad Minima"
                            Else
                                Observaciones = Observaciones & " - " & "Inferior Edad Minima"
                            End If

                        End If

                        If CInt(Edad) > CInt(EdadMaxima) Then
                            Concepto = "Edad mayor a permitida"
                            Vigente = Edad
                            Actualizado = EdadMaxima
                            Call IngresarEnCambios()

                            ExcluidoPorEdad = "1"

                            If Observaciones = Nothing Then
                                Observaciones = "Supera Edad Maxima"
                            Else
                                Observaciones = Observaciones & " - " & "Supera Edad Maxima"
                            End If

                        End If
                    End If

                    If Observaciones <> Nothing Then
                        Call AgregarObservaciones_Tabla_Adherentes()
                        Observaciones = Nothing
                    End If

                    If ExcluidoPorEdad <> Nothing Then
                        Call AgregarExcluirXEdad_Tabla_Adherentes()
                        ExcluidoPorEdad = Nothing
                    End If

                End While
            End If
            dr2.Close()
        Catch ex As Exception
            dr2.Close()
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub ControlarSAEntreMinimaYMaxima()
        SAAjustada = Nothing

        If CInt(SUMAASEGURADA) > CInt(SAMaxima) Then
            SAAjustada = SAMaxima
            SUMAASEGURADA = SAMaxima
        End If

        If CInt(SUMAASEGURADA) < CInt(SAMinima) Then
            SAAjustada = SAMinima
            SUMAASEGURADA = SAMinima
        End If

    End Sub




    Sub AjustarSueldo()

        Try
            ConsultaSQL = "SELECT Id,SumaAsegurada, Antiguedad, Sueldo, Apellido, Nombre"
            ConsultaSQL += " From Adherentes"

            DocumentoAProcesar = Nothing

            Call Consultar2()
            If dr2.HasRows Then
                While dr2.Read()
                    IdAdherente = CInt(dr2(0).ToString)
                    SUMAASEGURADA = dr2(1).ToString
                    AnosAntiguedad = dr2(2).ToString
                    SUELDO = CStr(CInt(dr2(3).ToString))
                    ApellidoNombre = dr2(4).ToString & " " & dr2(5).ToString

                    SueldoAjustado = CStr((CInt(SUMAASEGURADA) * 2) / AnosAntiguedad)
                    SueldoAjustado = Format(CSng(SueldoAjustado), "####,00")

                    If CSng(SUELDO) <> CSng(SueldoAjustado) Then
                        Call ActualizarSueldo()
                        Concepto = "Sueldo ajustado"
                        Vigente = SUELDO
                        Actualizado = SueldoAjustado
                        Call IngresarEnCambios()
                    End If



                End While
            End If

            dr2.Close()
        Catch ex As Exception
            dr2.Close()
            MsgBox(ex.Message)
        End Try
    End Sub

End Module
