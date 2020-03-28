Module ModuloConsultas
    Public ApellidoNombre, Concepto, Vigente, Actualizado As String

    Sub LlenarTipoContrato()

        Try


            ConsultaSQL = "SELECT TipoContrato"
            ConsultaSQL += " FROM Variables"
            ConsultaSQL += " ORDER BY TipoContrato"

            FPrincipal.CboTipoContrato.Items.Clear()

            Call Consultar()
            If dr.HasRows Then
                While dr.Read()
                    FPrincipal.CboTipoContrato.Items.Add(dr(0).ToString)

                End While
            End If

            dr.Close()
        Catch ex As Exception
            dr.Close()
            MsgBox(ex.Message)
        End Try

    End Sub
    Sub BuscarVariables()

        Try

            ConsultaSQL = "SELECT EdadMinima,EdadMaximaIngreso, SAMinima, SAMaxima,EdadMaximaPermanencia"
            ConsultaSQL += " From Variables"
            ConsultaSQL += " Where TipoContrato='" & FPrincipal.CboTipoContrato.Text & "'"


            FPrincipal.TxEdadMinima.Text = Nothing
            FPrincipal.TxEdadMaxima.Text = Nothing
            FPrincipal.TxSAMinima.Text = Nothing
            FPrincipal.TxSAMaxima.Text = Nothing
            FPrincipal.txEdadPermanencia.Text = Nothing

            EdadMinima = 0
            EdadMaxima = 0
            EdadPermanencia = 0
            SAMinima = 0
            SAMaxima = 0

            Call Consultar()
            If dr.HasRows Then
                dr.Read()
                EdadMinima = dr(0).ToString
                EdadMaxima = dr(1).ToString
                SAMinima = dr(2).ToString
                SAMaxima = dr(3).ToString
                EdadPermanencia = dr(4).ToString
            End If


            FPrincipal.TxEdadMinima.Text = EdadMinima
            FPrincipal.TxEdadMaxima.Text = EdadMaxima
            FPrincipal.TxSAMinima.Text = Format(CInt(SAMinima), "#,###")
            FPrincipal.TxSAMaxima.Text = Format(CInt(SAMaxima), "#,###")
            FPrincipal.txEdadPermanencia.Text = EdadPermanencia

            dr.Close()



        Catch ex As Exception
            dr.Close()
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub EliminarVigentesActual()
        SQL = "DELETE * FROM Adherentes where ORIGEN='Vigentes'"
        Call EliminarEnAcces()
    End Sub


    Sub EliminarTablaAdherentes()
        SQL = "DELETE * FROM Adherentes"
        Call EliminarEnAcces()
    End Sub

    Sub IngresarVigentes()

        SQL = "INSERT INTO Adherentes ( IdPolicy, CUIL,APELLIDO,NOMBRE,SEXO,FNACIMIENTO,GRUPO,SUELDO,FIngreso,SUMAASEGURADA,BENEFICIARIO,Origen)"
        SQL = SQL & " Values ("
        SQL = SQL & "'" & IdPolicy & "',"
        SQL = SQL & "'" & CUIL & "',"
        SQL = SQL & "'" & APELLIDO & "',"
        SQL = SQL & "'" & NOMBRE & "',"
        SQL = SQL & "'" & SEXO & "',"
        SQL = SQL & "'" & FNACIMIENTO & "',"
        SQL = SQL & "'" & GRUPO & "',"
        SQL = SQL & "'" & SUELDO & "',"
        SQL = SQL & "'" & FINGRESO & "',"
        SQL = SQL & "'" & SUMAASEGURADA & "',"
        SQL = SQL & "'" & BENEFICIARIO & "',"
        SQL = SQL & "'Vigentes'"
        SQL = SQL & ")"

        Call IngresarEnAcces()

    End Sub
    Sub EliminarActualizado()
        SQL = "DELETE * FROM Adherentes where ORIGEN='Actualizado'"
        Call EliminarEnAcces()

    End Sub
    Sub IngresarActualizado()

        SQL = "INSERT INTO Adherentes ( Apellido, Nombre,Documento,FNacimiento,FIngreso,Sueldo,SumaAsegurada,Origen)"
        SQL = SQL & " Values ("
        SQL = SQL & "'" & APELLIDO & "',"
        SQL = SQL & "'" & NOMBRE & "',"
        SQL = SQL & "'" & Documento & "',"
        SQL = SQL & "'" & FNACIMIENTO & "',"
        SQL = SQL & "'" & FINGRESO & "',"
        SQL = SQL & "'" & SUELDO & "',"
        SQL = SQL & "'" & SUMAASEGURADA & "',"
        SQL = SQL & "'Actualizado'"
        SQL = SQL & ")"

        Call IngresarEnAcces()

    End Sub


    Sub AgregarSexoA_Tabla_DatosActualizados()
        If APELLIDO = Nothing Then
            Exit Sub
        End If
        SQL = "UPDATE Adherentes SET "
        SQL += "Apellido='" & APELLIDO & "',"
        SQL += "Nombre='" & NOMBRE & "',"
        SQL += "Sexo='" & SEXO & "'"
        SQL += " where id=" & IdAdherente

        Call IngresarEnAcces()
    End Sub


    Sub AgregarSexoA_TablaSexo()

        NombreAIngresar = Trim(NombreAIngresar)

        SQL = "INSERT INTO Sexo ( Nombre, Apellido, Sexo)"
        SQL = SQL & " Values ("
        SQL = SQL & "'" & NombreAIngresar & "',"
        SQL = SQL & "'" & ApellidoAIngresar & "',"
        SQL = SQL & "'" & SexoAIngresar & "'"
        SQL = SQL & ")"

        Call IngresarEnAcces()

    End Sub


    Sub EliminarNombreDeTablaSexo()

        SQL = "DELETE * From Sexo Where Nombre ='" & NOMBRE & "'"
        Call EliminarEnAcces()

    End Sub


    Sub EliminarApellidoDeTablaSexo()

        SQL = "DELETE * From Sexo Where Apellido ='" & APELLIDO & "'"
        Call EliminarEnAcces()

    End Sub


    Sub AgregarEdad_Tabla_Adherentes()
        SQL = "UPDATE Adherentes SET "
        SQL += "Edad='" & Edad & "'"
        SQL += " WHERE id=" & IdAdherente

        Call IngresarEnAcces()
    End Sub

    Sub AgregarAntiguedad_Tabla_Adherentes()
        SQL = "UPDATE Adherentes SET "
        SQL += "Antiguedad='" & CStr(AnosAntiguedad) & "'"
        SQL += " WHERE id=" & IdAdherente

        Call IngresarEnAcces()
    End Sub


    Sub AgregarSumaAsegurada_Tabla_adherentes()
        SQL = "UPDATE Adherentes SET "
        SQL += "SumaAsegurada='" & CStr(SUMAASEGURADA) & "'"
        SQL += " WHERE id=" & IdAdherente

        Call IngresarEnAcces()
    End Sub

    Sub AgregarCUIL_Tabla_Adherentes()
        SQL = "UPDATE Adherentes SET "
        SQL += "CUIL='" & CUIL & "'"
        SQL += " WHERE id=" & IdAdherente

        Call IngresarEnAcces()
    End Sub


    Sub EliminarCambios()
        SQL = "DELETE * FROM Cambios"
        Call EliminarEnAcces()

    End Sub

    Sub IngresarEnCambios()
        SQL = "INSERT INTO Cambios (ApellidoNombre, CONCEPTO,VIGENTE,ACTUALIZADO)"
        SQL = SQL & " Values ("

        SQL = SQL & "'" & ApellidoNombre & "',"
        SQL = SQL & "'" & Concepto & "',"
        SQL = SQL & "'" & Vigente & "',"
        SQL = SQL & "'" & Actualizado & "'"
        SQL = SQL & ")"

        Call IngresarEnAcces()

    End Sub


    Sub AgregarObservaciones_Tabla_Adherentes()
        SQL = "UPDATE Adherentes SET "
        SQL += "Observaciones='" & Observaciones & "'"
        SQL += " WHERE id=" & IdAdherente

        Call IngresarEnAcces()
    End Sub

    Sub AgregarExcluirXEdad_Tabla_Adherentes()
        SQL = "UPDATE Adherentes SET "
        SQL += "ExcluidoPorEdad='" & ExcluidoPorEdad & "'"
        SQL += " WHERE id=" & IdAdherente

        Call IngresarEnAcces()
    End Sub



    Sub AjustarSAAdherente()
        SQL = "UPDATE Adherentes SET "
        SQL += "SUMAASEGURADA='" & SUMAASEGURADA & "'"
        SQL += " WHERE id=" & IdAdherente

        Call IngresarEnAcces()
    End Sub



    Sub MarcarEliminar()
        SQL = "UPDATE Adherentes SET "
        SQL += "Accion='Eliminar'"
        SQL += " WHERE CUIL like'%" & Documento & "%'"

        Call IngresarEnAcces()
    End Sub


    Sub MarcarEliminarXid()
        SQL = "UPDATE Adherentes SET "
        SQL += "Accion='Eliminar'"
        SQL += " WHERE Id =" & IdAdherente

        Call IngresarEnAcces()
    End Sub


    Sub MarcarAgregar()
        SQL = "UPDATE Adherentes SET "
        SQL += "Accion='Agregar'"
        SQL += " WHERE id =" & IdAdherente

        Call IngresarEnAcces()
    End Sub

    Sub MarcarRepetido()
        SQL = "UPDATE Adherentes SET "
        SQL += "Accion='Repetido'"
        SQL += " WHERE id =" & IdAdherente

        Call IngresarEnAcces()
    End Sub

    Sub Actualizado_MarcarVigente()
        SQL = "UPDATE Adherentes SET "
        SQL += "Marcado='1'"
        SQL += " WHERE id=" & IdAdherente2

        Call IngresarEnAcces()
    End Sub

    Sub Actualizado_Agregar()
        SQL = "UPDATE Adherentes SET "
        SQL += "Accion='Agregar'"
        SQL += " WHERE id =" & IdAdherente

        Call IngresarEnAcces()
    End Sub

    Sub Actualizado_Eliminar()
        SQL = "UPDATE Adherentes SET "
        SQL += "Accion='Eliminar'"
        SQL += " WHERE Marcado is null and Origen='Vigentes'"

        Call IngresarEnAcces()
    End Sub

    Sub ActualizarSueldo()
        SQL = "UPDATE Adherentes SET "
        SQL += "Sueldo='" & SueldoAjustado & "'"
        SQL += " WHERE id=" & IdAdherente

        Call IngresarEnAcces()
    End Sub


End Module
