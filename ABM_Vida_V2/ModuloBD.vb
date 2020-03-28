Module ModuloBD
    Public RutaLocal As String = "C:\Publico\ABM_Vida_V2\Archivos\"
    ' Public CONN As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & RutaLocal & "Digito.accdb;Persist Security Info=False")

    Public CONN As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & "AMB_Vida2.accdb;Persist Security Info=False")

    Public RutaAplicacion As String = "C:\Publico\ABM_Vida_V2\ABM_Vida_V2\bin\Debug"
    Public RutaRed As String = RutaAplicacion

    'Public CONN As New System.Data.OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data source=" & RutaAplicacion & "PCFamiliar.mdb")

    'Public CONN As New System.Data.OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data source=PCHogar.mdb")

    Public BaseDatos As String
    Public ConsultaAlmacenada As String
    Public Resultados As OleDb.OleDbDataReader


    Public cmd As New OleDb.OleDbCommand
    Public dr As OleDb.OleDbDataReader

    Public cmd2, cmd3 As New OleDb.OleDbCommand
    Public dr2, dr3 As OleDb.OleDbDataReader
    Public X As Byte
    Public Conecta As New OleDb.OleDbConnection()
    Public Comando As New OleDb.OleDbCommand()

    Public SQL As String = ""


    Public ConsultaSQL As String


    Public Existente As Byte = 0





    Sub Consultar()
        Try
            cmd.Connection = CONN
            cmd.CommandType = CommandType.Text
            cmd.CommandText = ConsultaSQL



            dr = cmd.ExecuteReader()

        Catch ex As Exception

            MsgBox(ex.ToString)


        End Try


    End Sub

    Sub Consultar2()
        Try
            cmd2.Connection = CONN
            cmd2.CommandType = CommandType.Text
            cmd2.CommandText = ConsultaSQL



            dr2 = cmd2.ExecuteReader()

        Catch ex As Exception

            MsgBox(ex.ToString)


        End Try


    End Sub

    Sub Consultar3()
        Try
            cmd3.Connection = CONN
            cmd3.CommandType = CommandType.Text
            cmd3.CommandText = ConsultaSQL



            dr3 = cmd3.ExecuteReader()

        Catch ex As Exception

            MsgBox(ex.ToString)


        End Try


    End Sub

    Sub Conectarse()
        Try


            CONN.Close()


            CONN.Open()


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try



    End Sub
    Sub ConectarBD()
        Dim Info As String


        Try
            Info = "Provider=Microsoft.Jet.OLEDB.4.0;"
            Info = Info & "PASSWORD=;"
            Info = Info & "USER ID=;"
            Info = Info & "DATA SOURCE = "
            Info = Info & RutaRed
            Info = Info & BaseDatos & ".mdb"


            Conecta.ConnectionString = Info
            Conecta.Open()


        Catch exc As OleDb.OleDbException
            MsgBox("Error al abrir la base de datos", MsgBoxStyle.Exclamation, "MENSAJE")
            MsgBox(exc.ToString)
        Finally
        End Try
    End Sub


    Sub ConsultaParametroString(ByVal ConsultaAlmacenada As String,
                    Optional ByVal ValorParametro1 As String = "",
                    Optional ByVal ValorParametro2 As String = "",
                    Optional ByVal ValorParametro3 As String = "",
                    Optional ByVal ValorParametro4 As String = "",
                    Optional ByVal ValorParametro5 As String = "",
                    Optional ByVal ValorParametro6 As String = "",
                    Optional ByVal ValorParametro7 As String = "",
                    Optional ByVal ValorParametro8 As String = "",
                     Optional ByVal ValorParametro9 As String = "",
                    Optional ByVal ValorParametro10 As String = "")
        Try
            Dim Parametro As OleDb.OleDbParameter
            Call ConectarBD()
            Comando = New OleDb.OleDbCommand()
            Comando.CommandType = CommandType.StoredProcedure
            Comando.CommandText = ConsultaAlmacenada



            If ValorParametro1 <> Nothing Then
                Parametro = Comando.Parameters.Add(New OleDb.OleDbParameter("Parametro1", ValorParametro1))
            End If
            If ValorParametro2 <> Nothing Then
                Parametro = Comando.Parameters.Add(New OleDb.OleDbParameter("Parametro2", ValorParametro2))
            End If

            If ValorParametro3 <> Nothing Then
                Parametro = Comando.Parameters.Add(New OleDb.OleDbParameter("Parametro3", ValorParametro3))
            End If

            If ValorParametro4 <> Nothing Then
                Parametro = Comando.Parameters.Add(New OleDb.OleDbParameter("Parametro4", ValorParametro4))
            End If

            If ValorParametro5 <> Nothing Then
                Parametro = Comando.Parameters.Add(New OleDb.OleDbParameter("Parametro5", ValorParametro5))
            End If

            If ValorParametro6 <> Nothing Then
                Parametro = Comando.Parameters.Add(New OleDb.OleDbParameter("Parametro6", ValorParametro6))
            End If

            If ValorParametro7 <> Nothing Then
                Parametro = Comando.Parameters.Add(New OleDb.OleDbParameter("Parametro7", ValorParametro7))
            End If

            If ValorParametro8 <> Nothing Then
                Parametro = Comando.Parameters.Add(New OleDb.OleDbParameter("Parametro8", ValorParametro8))
            End If

            If ValorParametro9 <> Nothing Then
                Parametro = Comando.Parameters.Add(New OleDb.OleDbParameter("Parametro9", ValorParametro9))
            End If

            If ValorParametro10 <> Nothing Then
                Parametro = Comando.Parameters.Add(New OleDb.OleDbParameter("Parametro10", ValorParametro10))
            End If


            Comando.Connection = Conecta
            Resultados = Comando.ExecuteReader

        Catch ex As Exception
            'MsgBox("Error en Parametros " & ConsultaAlmacenada, MsgBoxStyle.Information, "ERROR")
        Finally

        End Try
    End Sub


    Sub IngresarEnAcces()
        Try
            cmd.CommandType = CommandType.Text
            cmd.Connection = CONN

            'toma el valor sql del programa
            cmd.CommandText = SQL

            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Sub EliminarEnAcces()
        Try
            cmd.CommandType = CommandType.Text
            cmd.Connection = CONN


            cmd.CommandText = SQL

            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try
    End Sub





End Module
