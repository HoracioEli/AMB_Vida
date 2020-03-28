Module ModuloAccion
    Public Coincidente As Byte
    Sub Bajas_RecuperaDocumentoADarDeBaja()

        Try
            ConsultaSQL = "SELECT Id,Documento, Apellido, Nombre"
            ConsultaSQL += " From Adherentes"
            ConsultaSQL += " where Origen='Actualizado'"
            Contador = 0
            Call Consultar2()
            If dr2.HasRows Then
                While dr2.Read()
                    Contador += 1
                    IdAdherente = CInt(dr2(0).ToString)
                    Documento = dr2(1).ToString
                    APELLIDO = dr2(2).ToString
                    NOMBRE = dr2(3).ToString
                    If Documento = Nothing Then
                        Call Bajas_XApellidoYNombre()
                    Else
                        Call MarcarEliminar()
                    End If

                    FPrincipal.Text = "Procesando el registro de: " & APELLIDO & " " & NOMBRE
                End While
            End If
            FPrincipal.Text = "Movimientos Vida colectivo en Policy"
            MsgBox("Cantidad de adherentes dados de baja " & Contador, MsgBoxStyle.Information, "PROCESO TERMINADO EN FORMA EXITOSA")
            dr2.Close()
        Catch ex As Exception
            dr2.Close()
            MsgBox(ex.Message)
        End Try
    End Sub



    Sub Bajas_XApellidoYNombre()

        Try
            ConsultaSQL = "SELECT Id, Apellido, Nombre"
            ConsultaSQL += " From Adherentes"
            ConsultaSQL += " where Apellido like'%" & APELLIDO & "%' and Nombre like '%" & NOMBRE & "%'"
            ConsultaSQL += " and Origen='Vigentes'"
            Call Consultar3()
            If dr3.HasRows Then
                While dr3.Read()
                    IdAdherente = CInt(dr3(0).ToString)
                    ApellidoNombre = dr3(1).ToString & " "
                    ApellidoNombre += dr3(2).ToString

                    Mensaje = "Coincidencia de nombre encontrada " & APELLIDO & " " & NOMBRE & Chr(10)
                    Mensaje += "se asemeja a " & ApellidoNombre & Chr(10)
                    Mensaje += "¿Dar de baja?"
                    MsgBox(Mensaje, MsgBoxStyle.OkCancel, "SE REQUIERE CONFIRMACION")
                    If vbOK Then
                        Call MarcarEliminarXid()
                    End If

                End While
            End If

            dr3.Close()
        Catch ex As Exception
            dr3.Close()
            MsgBox(ex.Message)
        End Try
    End Sub


    Sub Altas_VerificarDuplicado()

        Try
            ConsultaSQL = "SELECT Id,Documento, Apellido, Nombre"
            ConsultaSQL += " From Adherentes"
            ConsultaSQL += " where Origen='Actualizado'"
            Contador = 0
            Call Consultar2()
            If dr2.HasRows Then
                While dr2.Read()
                    IdAdherente = CInt(dr2(0).ToString)
                    Documento = dr2(1).ToString
                    APELLIDO = dr2(2).ToString
                    NOMBRE = dr2(3).ToString
                    ApellidoNombre = APELLIDO & " " & NOMBRE
                    Coincidente = 0
                    Call Altas_VerificarDuplicadoPaso2()

                    If Coincidente = 1 Then ' significa que el documento que se quiere dar de alta ya está vigente
                        Mensaje = "El documento " & Documento & " de " & ApellidoNombre & " que se desea dar de alta ya existe para: " & Chr(10) & Chr(10)
                        Mensaje += APELLIDO & " " & NOMBRE & " (CUIL: " & CUIL & ")" & Chr(10) & Chr(10)
                        Mensaje += "Se dejará el adherente existente."
                        MsgBox(Mensaje, MsgBoxStyle.Critical, "DOCUMENTO EXISTENTE")
                        Call MarcarRepetido()
                        Concepto = "Repetido"
                        Vigente = APELLIDO & " " & NOMBRE & "(" & CUIL & ")"
                        Actualizado = Documento
                        Call IngresarEnCambios()

                    Else
                        Call MarcarAgregar()
                        Contador += 1
                    End If

                    FPrincipal.Text = "Procesando el registro de: " & APELLIDO & " " & NOMBRE
                End While
            End If
            FPrincipal.Text = "Movimientos Vida colectivo en Policy"
            MsgBox("Cantidad de adherentes dados de ALTA " & Contador, MsgBoxStyle.Information, "PROCESO TERMINADO EN FORMA EXITOSA")
            dr2.Close()
        Catch ex As Exception
            dr2.Close()
            MsgBox(ex.Message)
        End Try
    End Sub


    Sub Altas_VerificarDuplicadoPaso2()
        Try
            ConsultaSQL = "SELECT CUIL, Apellido, Nombre"
            ConsultaSQL += " From Adherentes"
            ConsultaSQL += " where Origen='Vigentes' and CUIL Like '%" & Documento & "%'"
            Coincidente = 0
            Call Consultar3()
            If dr3.HasRows Then
                While dr3.Read()
                    CUIL = dr3(0).ToString
                    APELLIDO = dr3(1).ToString
                    NOMBRE = dr3(2).ToString
                    Coincidente = 1
                End While
            End If
            dr3.Close()
        Catch ex As Exception
            dr3.Close()
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub Actualizado_BuscarDocumento()

        Try
            ConsultaSQL = "SELECT Id,Documento, Apellido, Nombre"
            ConsultaSQL += " From Adherentes where documento Is Not Null"
            Contador = 0
            Call Consultar2()
            If dr2.HasRows Then
                While dr2.Read()
                    Contador += 1
                    IdAdherente = CInt(dr2(0).ToString)
                    Documento = dr2(1).ToString
                    APELLIDO = dr2(2).ToString
                    NOMBRE = dr2(3).ToString
                    Call Actualizado_VerificarDuplicadoPaso2()

                    FPrincipal.Text = "Procesando el registro de: " & APELLIDO & " " & NOMBRE
                End While
            End If
            FPrincipal.Text = "Movimientos Vida colectivo en Policy"
            MsgBox("Cantidad de adherentes dados de baja " & Contador, MsgBoxStyle.Information, "PROCESO TERMINADO EN FORMA EXITOSA")
            dr2.Close()
        Catch ex As Exception
            dr2.Close()
            MsgBox(ex.Message)
        End Try
    End Sub



    Sub Actualizado_VerificarDuplicadoPaso2()
        Try
            Dim Existente As Byte = 0
            ConsultaSQL = "SELECT CUIL, Apellido, Nombre, Origen, Marcado, Accion, Id"
            ConsultaSQL += " From Adherentes"
            ConsultaSQL += " where CUIL Like '%" & Documento & "%' and Origen='Vigentes'"
            Coincidente = 0
            Call Consultar3()
            If dr3.HasRows Then
                While dr3.Read()
                    Existente = 1
                    CUIL = dr3(0).ToString
                    ApellidoNombre = dr3(1).ToString & " "
                    ApellidoNombre += dr3(2).ToString
                    Origen = dr3(3).ToString
                    Marcado = dr3(4).ToString
                    Accion = dr3(5).ToString
                    IdAdherente2 = CInt(dr3(6).ToString)
                    Call Actualizado_Paso3_Tomardecision()
                End While
            End If
            dr3.Close()

            If Existente = 0 Then
                Call Actualizado_Agregar()
            End If


        Catch ex As Exception
            dr3.Close()
            MsgBox(ex.Message)
        End Try
    End Sub


    Sub Actualizado_Paso3_Tomardecision()

        If Origen = "Vigentes" And Marcado = "1" Then 'significa que está repetido, es decir, ya se marcó y ahora se pide volver a marcar
            Mensaje = "El documento " & Documento & " perteneciente a: " & APELLIDO & " " & NOMBRE & " se encuentra repetido" & Chr(10)
            Mensaje += "con " & ApellidoNombre & "(" & CUIL & ")" & Chr(10)
            Mensaje += "no se incluirá en el archivo excel a importar"
            MsgBox(Mensaje, MsgBoxStyle.Critical, "ADHERENTE REPETIDO")
        End If


        If Origen = "Vigentes" And Marcado = Nothing Then 'el actualizado está vigente, por eso lo deja marcado
            Call Actualizado_MarcarVigente()
        End If

    End Sub





End Module
