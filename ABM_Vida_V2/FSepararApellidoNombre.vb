Public Class FSepararApellidoNombre

    Public LlegoAFin As Byte
    Public ElementoABuscar As String
    Public IntervieneOperador, IntervieneOperadorPaso2 As Byte
    Public ApellidoEncontrado, NombreEncontrado, SexoEncontrado, IdSexo As String

    Public Adherente As String
    Public NombreABuscar As String

    Private Sub btnComenzar_Click(sender As Object, e As EventArgs) Handles btnComenzar.Click
        btnComenzar.Visible = False
        Call Paso0()
    End Sub
    Sub Paso0()
        ' busca en tabla ACTUALIZADOS los datos de Apellido, Nombre e ID x cada registro
        ' lo primero que hace es ver si en la tabla ACTUALIZADOS estàn identificados APELLIDO y NOMBRE
        ConsultaSQL = "SELECT Apellido, Nombre, Id"
        ConsultaSQL += " From Adherentes"
        Call Consultar2()

        ' comienza a recorrer cada uno de los registros
        Call Paso1()
    End Sub
    Sub Paso1()
        'SI CELDA NOMBRE TIENE INDICADO EL NOMBRE, 
        ' Si lo están asigna a TX1.TEXT= APELLIDO - CBO1 = "Apellido" - CboSexo1.visible=false
        ' Y A TX2.TEXT= NOMBRE - CBO2 = "Nombre" - CboSexo2.visible=true POR AHORA SIN IDENTIFICAR SI ES Masculino o Femenino


        'SI CELDA NOMBRE NO TIENE INDICADO NOMBRE
        'significa que en APELLIDO está el nombre y el apellido, TODO JUNTO.
        ' hay que separarlos. Esto lo hace:
        'DIVIDIR NOMBRE (primero busca el caracter que los divide "," - ";" - " " (espacio)
        ' luego va diviendo cada parte integrante de apellido (PERO NO SABE SI ES NOMBRE O APELLIDO)
        ' deposita cada parte en TX1, TX2, TX3...
        Call BuscarAdherente() ' va al siguiente registro (comienza con el primero)

        If LlegoAFin = 1 Then
            Exit Sub
        End If

        'Va recorriendo cada uno de TX1, TX2...
        'toma el valor "ELEMENTOABUSCAR"

        'SI ENCUENTRA EN TABLA SEXO
        'ASIGNA A CBO1, CBO2... segun en que columna APELLIDO - NOMBRE encontrò coincidencia
        ' Ejemplo: "FIGUEROA" lo encontrò en columna APELLIDO, entonces en CBO1 = "Apellido" - CboSexo1.visible=False

        'SI NO ENCUENTRA PIDE AYUDA AL OPERADOR
        'Asigna a INTERVIENEOPERADOR= 1
        'el programa avisa con un MENSAJE y le asigna el control al operador

        ' primero ARMA un posible nombre compuesto y luego busca
        Call ArmarNombreCompuestoParaBuscar()
        Call RutinaParaBuscarSexoEnTablaSexo()

        If IntervieneOperador = 1 Then 'significa que no encontró en tabla sexo por nombre o apellido
            Dim Mensaje As String
            Mensaje = "Debe indicarse, para cada elemento, si se trata de un APELLIDO o un NOMBRE. " & Chr(10)
            Mensaje += "En el caso de un NOMBRE, debe asignarse el SEXO." & Chr(10)
            Mensaje += "Es importante hacerlo bien, porque de esta decisión dependerán decisiones automáticas para futuras operaciones" & Chr(10)
            Mensaje += "SI no está indicar INDEFINIDO"

            MsgBox(Mensaje, MsgBoxStyle.Information, "SE REQUIERE LA PARTICIPACION DEL OPERADOR")
            cbo1.Select()

        Else
            Call Paso2()
        End If
    End Sub
    Sub Paso2()

        ' si estamos en este paso es que INTERVIENEOPERADOR=1
        ' hay algùn elemnento que no encontrò en la tabla sexo
        ' se pide al operador que aporte informaciòn y ahora, lo primero que hace es 
        ' volcar la AYUDA del operador en la tabla sexo. Ejemplo
        ' ELEMENTOABUSCAR= "MARIA" - no lo encontró
        ' le pide al operador que indique si MARIA es Apellido o Nombre
        ' Si es nombre, también pedirá que le indique el sexo
        ' Si se trata de un nombre compuesto , MARIA DEL CARMEN, el operador puede señalarlo para
        ' que ingrese como NOMBRECOMPUESTO en la tabla de SEXO

        Call ControlarIngresarSexo()

        'ahora el NOMBRE o APELLIDO ya està cargado en tabla SEXO
        'entonces ahora tiene que volver a buscar el mismo registro en TABLA SEXO que antes no encontró
        Call RutinaParaBuscarSexoEnTablaSexo()
        'ahora lo va a encontrar, entonces este ADHERENTE estará dividido en APELLIDO y NOMBRE
        ' entonces lo que tengo que hacer es cargar el DATO en tabla ACTUALIZADO
        ' pero primero debe armar el dato, ya que APELLIDO puede ocupar mas de un TX1
        ' por ejemplo si:
        ' TX1= "FIGUEROA" y TX2 "IBAÑES" ambos son apellido, por tanto tiene que unirlos.
        ' lo mismo sucede con el nombre.
        ' al final, tendré solo un APELLIDO (simple o compuesto) y un solo NOMBRE (simple o compuesto)
        ' de eso se encarga RESOLVERUPDATEACTUALIZADO

        ' dentro de esta subrutina también se verifica que en SEXO haya coincidencia.
        ' esto lo hace DEFINIRSEXO
        ' si CBOSEXO1 = Masculino y CBOSEXO2= Femenino
        ' reportará un error, ya que solamente puede haber un sexo para cada adherente
        ' INTERVIENEOPERADOR=1
        Call ResolverUpdateActualizado()

        If IntervieneOperadorPaso2 = 0 Then
            Call AgregarSexoA_Tabla_DatosActualizados()
            Call Adherentes_ListarGrid()
            Call LimpiarControles()
        Else
            'esto significa que al hacer el control para ingresar, habia dos sexos (Femenino y Masculino)
            'o bien en un Nombre faltaba indicar el Sexo - VACIO
            'o bien se habia indicado INDEFINIDO y no habia marcado un MASCULINO o un FEMENINO
            cbo1.Select()
            Exit Sub
            'se detiene
        End If

        Call Paso1()

    End Sub
    Sub BuscarAdherente()
        Try
            If dr2.HasRows Then
                dr2.Read()

                APELLIDO = dr2(0).ToString
                NOMBRE = dr2(1).ToString
                IdAdherente = CInt(dr2(2).ToString)
                Call SepararApellido_Nombre()

            End If

        Catch ex As Exception
            MsgBox("Fin del listado", MsgBoxStyle.Information, "Separar apellido y nombre y asignar Sexo")
            LlegoAFin = 1
            dr2.Close()
        End Try



    End Sub
    Sub ArmarNombreCompuestoParaBuscar()
        ' REALIZA UNA BUSQUEDA SUPONIENDO QUE LOS DATOS ENCONTRADOS PUEDEN
        'SER UN NOMBRE COMPUESTO. POR EJEMPLO: MARIA DEL CARMEN
        'vamos a ver en :
        ' Tx2 = MARIA(sin definir si es nombre o apellido ni sexo)
        ' TX3 = DEL
        ' TX4 = CARMEN

        'Y QUE TX1 está el apellido


        If Cbo2.Text <> "Apellido" Then
            ElementoABuscar = Tx2.Text
        End If

        If Cbo3.Text <> "Apellido" Then
            ElementoABuscar += " " & Tx3.Text
        End If

        If Cbo4.Text <> "Apellido" Then
            ElementoABuscar += " " & Tx4.Text
        End If

        ElementoABuscar = Trim(ElementoABuscar)

        Call BuscarEnTablaSexo()

        If IntervieneOperador = 0 Then 'significa que encontró. Es nombre compuesto

            Tx2.Text = ElementoABuscar
            Tx3.Text = Nothing
            Tx4.Text = Nothing
            Cbo2.Text = "Nombre"
            CboSexo2.Text = SexoEncontrado
            Exit Sub

        End If


        'REALIZA UNA SEGUNDA BUSQUEDA, PERO AHORA DESDE TX1
        ' SUPONIENDO QUE PRIMERO ESTA EL NOMBRE COMPUESTO Y LUEGO EL APELLIDO


        If cbo1.Text <> "Apellido" Then
            ElementoABuscar = Tx1.Text
        End If

        If Cbo2.Text <> "Apellido" Then
            ElementoABuscar += " " & Tx2.Text
        End If

        If Cbo3.Text <> "Apellido" Then
            ElementoABuscar += " " & Tx3.Text
        End If
        ElementoABuscar = Trim(ElementoABuscar)
        Call BuscarEnTablaSexo()

        If IntervieneOperador = 0 Then 'significa que no encontró, se presume que no es un nombre compuesto
            Tx1.Text = ElementoABuscar
            Tx2.Text = Nothing
            Tx3.Text = Nothing
            cbo1.Text = "Nombre"
            CboSexo1.Text = SexoEncontrado

        End If

    End Sub
    Sub RutinaParaBuscarSexoEnTablaSexo()
        IntervieneOperador = 0 'vuelve el valor a cero
        'If Tx1.Text = Nothing Then
        ' Exit Sub
        'End If
        ElementoABuscar = Tx1.Text
        Call BuscarEnTablaSexo()

        If ApellidoEncontrado <> Nothing Then
            cbo1.Text = "Apellido"
            lbID1.Text = IdSexo
        ElseIf NombreEncontrado <> Nothing Then
            cbo1.Text = "Nombre"
            CboSexo1.Text = SexoEncontrado
            lbID1.Text = IdSexo
        End If


        If Tx2.Text = Nothing Then
            Exit Sub
        End If
        ElementoABuscar = Tx2.Text
        Call BuscarEnTablaSexo()

        If ApellidoEncontrado <> Nothing Then
            Cbo2.Text = "Apellido"
            lbID2.Text = IdSexo
        ElseIf NombreEncontrado <> Nothing Then
            Cbo2.Text = "Nombre"
            CboSexo2.Text = SexoEncontrado
            lbID2.Text = IdSexo
        End If


        If Tx3.Text = Nothing Then
            Exit Sub
        End If
        ElementoABuscar = Tx3.Text
        Call BuscarEnTablaSexo()

        If ApellidoEncontrado <> Nothing Then
            Cbo3.Text = "Apellido"
            lbID3.Text = IdSexo
        ElseIf NombreEncontrado <> Nothing Then
            Cbo3.Text = "Nombre"
            CboSexo3.Text = SexoEncontrado
            lbID3.Text = IdSexo
        End If


        If Tx4.Text = Nothing Then
            Exit Sub
        End If
        ElementoABuscar = Tx4.Text
        Call BuscarEnTablaSexo()

        If ApellidoEncontrado <> Nothing Then
            Cbo4.Text = "Apellido"
            lbID4.Text = IdSexo
        ElseIf NombreEncontrado <> Nothing Then
            Cbo4.Text = "Nombre"
            CboSexo4.Text = SexoEncontrado
            lbID4.Text = IdSexo
        End If


        If Tx5.Text = Nothing Then
            Exit Sub
        End If
        ElementoABuscar = Tx5.Text
        Call BuscarEnTablaSexo()

        If ApellidoEncontrado <> Nothing Then
            Cbo5.Text = "Apellido"
            lbID5.Text = IdSexo
        ElseIf NombreEncontrado <> Nothing Then
            Cbo5.Text = "Nombre"
            CboSexo5.Text = SexoEncontrado
            lbID5.Text = IdSexo
        End If
    End Sub
    Sub BuscarEnTablaSexo()
        Try
            Me.Text = "Buscar en Tabla Sexo"
            ConsultaSQL = "SELECT Id, Nombre, Apellido,Sexo"
            ConsultaSQL += " From Sexo"
            ConsultaSQL += " where Nombre ='" & ElementoABuscar & "' " & "Or Apellido ='" & ElementoABuscar & "'"
            NombreEncontrado = Nothing
            ApellidoEncontrado = Nothing
            IdSexo = Nothing
            SexoEncontrado = Nothing


            Call Consultar()
            If dr.HasRows Then
                dr.Read()
                IdSexo = dr(0).ToString
                NombreEncontrado = dr(1).ToString
                ApellidoEncontrado = dr(2).ToString
                SexoEncontrado = dr(3).ToString
            Else
                IntervieneOperador = 1
            End If
            dr.Close()
        Catch ex As Exception
            dr.Close()
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub ControlarIngresarSexo()

        If lbID1.Text = Nothing Then 'significa que no hay que editar un valor existente en BD
            If Tx1.Text <> Nothing Then
                If cbo1.Text = "Apellido" Then
                    ApellidoAIngresar = Tx1.Text
                    NombreAIngresar = Nothing
                    SexoAIngresar = Nothing
                ElseIf cbo1.Text = "Nombre" Then
                    ApellidoAIngresar = Nothing
                    NombreAIngresar = Tx1.Text
                    SexoAIngresar = CboSexo1.Text
                ElseIf cbo1.Text = "Nombre Compuesto" Then
                    ApellidoAIngresar = Nothing
                    Call FormarNombreCompuesto()
                    SexoAIngresar = CboSexo1.Text
                End If
                Call AgregarSexoA_TablaSexo()
            End If
        End If

        If lbID2.Text = Nothing Then 'significa que no hay que editar un valor existente en BD
            If Tx2.Text <> Nothing Then
                If Cbo2.Text = "Apellido" Then
                    ApellidoAIngresar = Tx2.Text
                    NombreAIngresar = Nothing
                    SexoAIngresar = Nothing
                ElseIf Cbo2.Text = "Nombre" Then
                    ApellidoAIngresar = Nothing
                    NombreAIngresar = Tx2.Text
                    SexoAIngresar = CboSexo2.Text
                ElseIf Cbo2.Text = "Nombre Compuesto" Then
                    ApellidoAIngresar = Nothing
                    Call FormarNombreCompuesto()
                    SexoAIngresar = CboSexo2.Text
                End If
                Call AgregarSexoA_TablaSexo()
            End If
        End If

        If lbID3.Text = Nothing Then 'significa que no hay que editar un valor existente en BD
            If Tx3.Text <> Nothing Then
                If Cbo3.Text = "Apellido" Then
                    ApellidoAIngresar = Tx3.Text
                    NombreAIngresar = Nothing
                    SexoAIngresar = Nothing
                ElseIf Cbo3.Text = "Nombre" Then
                    ApellidoAIngresar = Nothing
                    NombreAIngresar = Tx3.Text
                    SexoAIngresar = CboSexo3.Text
                ElseIf Cbo3.Text = "Nombre Compuesto" Then
                    ApellidoAIngresar = Nothing
                    Call FormarNombreCompuesto()
                    SexoAIngresar = CboSexo3.Text
                End If
                Call AgregarSexoA_TablaSexo()
            End If
        End If


        If lbID4.Text = Nothing Then 'significa que no hay que editar un valor existente en BD
            If Tx4.Text <> Nothing Then
                If Cbo4.Text = "Apellido" Then
                    ApellidoAIngresar = Tx4.Text
                    NombreAIngresar = Nothing
                    SexoAIngresar = Nothing
                ElseIf Cbo4.Text = "Nombre" Then
                    ApellidoAIngresar = Nothing
                    NombreAIngresar = Tx4.Text
                    SexoAIngresar = CboSexo4.Text
                ElseIf Cbo4.Text = "Nombre Compuesto" Then
                    ApellidoAIngresar = Nothing
                    Call FormarNombreCompuesto()
                    SexoAIngresar = CboSexo4.Text
                End If
                Call AgregarSexoA_TablaSexo()
            End If
        End If

        If lbID5.Text = Nothing Then 'significa que no hay que editar un valor existente en BD
            If Tx5.Text <> Nothing Then
                If Cbo5.Text = "Apellido" Then
                    ApellidoAIngresar = Tx5.Text
                    NombreAIngresar = Nothing
                    SexoAIngresar = Nothing
                ElseIf Cbo5.Text = "Nombre" Then
                    ApellidoAIngresar = Nothing
                    NombreAIngresar = Tx5.Text
                    SexoAIngresar = CboSexo5.Text
                ElseIf Cbo5.Text = "Nombre Compuesto" Then

                    ApellidoAIngresar = Nothing
                    Call FormarNombreCompuesto()
                    SexoAIngresar = CboSexo5.Text
                End If
                Call AgregarSexoA_TablaSexo()
            End If
        End If


    End Sub
    Sub ResolverUpdateActualizado()
        Me.Text = "Resolver Update Actualizado"
        NOMBRE = Nothing
        APELLIDO = Nothing

        If cbo1.Text = "Apellido" And Tx1.Text <> Nothing Then
            APELLIDO = Tx1.Text & " "
        End If

        If Cbo2.Text = "Apellido" And Tx2.Text <> Nothing Then
            APELLIDO += Tx1.Text & " "
        End If

        If Cbo3.Text = "Apellido" And Tx3.Text <> Nothing Then
            APELLIDO += Tx1.Text & " "
        End If
        If Cbo4.Text = "Apellido" And Tx4.Text <> Nothing Then
            APELLIDO += Tx1.Text & " "
        End If

        If Cbo5.Text = "Apellido" And Tx5.Text <> Nothing Then
            APELLIDO += Tx1.Text & " "
        End If

        APELLIDO = Trim(APELLIDO)


        If cbo1.Text = "Nombre" Or cbo1.Text = "Nombre Compuesto" And Tx1.Text <> Nothing Then
            NOMBRE = Tx1.Text & " "
        End If


        If Cbo2.Text = "Nombre" Or Cbo2.Text = "Nombre Compuesto" And Tx2.Text <> Nothing Then
            NOMBRE += Tx2.Text & " "
        End If

        If Cbo3.Text = "Nombre" Or cbo1.Text = "Nombre Compuesto" And Tx3.Text <> Nothing Then
            NOMBRE += Tx3.Text & " "
        End If

        If Cbo4.Text = "Nombre" Or Cbo4.Text = "Nombre Compuesto" And Tx4.Text <> Nothing Then
            NOMBRE += Tx4.Text & " "
        End If

        If Cbo5.Text = "Nombre" Or Cbo5.Text = "Nombre Compuesto" And Tx5.Text <> Nothing Then
            NOMBRE += Tx5.Text & " "
        End If

        NOMBRE = Trim(NOMBRE)

        Call DefinirSexo()

    End Sub
    Sub Adherentes_ListarGrid()
        DataGridBusquedas.DataSource = Nothing
        DataGridBusquedas.Rows.Clear()

        ConsultaSQL = "Select id,Apellido,Nombre,Sexo from Adherentes"

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
    Sub DefinirSexo()

        Dim Masculino, Femenino, Vacio, Indefinido As Byte

        If CboSexo1.Visible = True Then
            Select Case CboSexo1.Text
                Case "Masculino"
                    Masculino = 1
                Case "Femenino"
                    Femenino = 1
                Case "Indifenido"
                    Indefinido = 1
                Case Else
                    Vacio = 1
            End Select
        End If


        If CboSexo2.Visible = True Then
            Select Case CboSexo2.Text
                Case "Masculino"
                    Masculino = 1
                Case "Femenino"
                    Femenino = 1
                Case "Indifenido"
                    Indefinido = 1
                Case Else
                    Vacio = 1
            End Select
        End If


        If CboSexo3.Visible = True Then
            Select Case CboSexo3.Text
                Case "Masculino"
                    Masculino = 1
                Case "Femenino"
                    Femenino = 1
                Case "Indifenido"
                    Indefinido = 1
                Case Else
                    Vacio = 1
            End Select
        End If


        If CboSexo4.Visible = True Then
            Select Case CboSexo4.Text
                Case "Masculino"
                    Masculino = 1
                Case "Femenino"
                    Femenino = 1
                Case "Indifenido"
                    Indefinido = 1
                Case Else
                    Vacio = 1
            End Select
        End If

        If CboSexo5.Visible = True Then

            Select Case CboSexo5.Text
                Case "Masculino"
                    Masculino = 1
                Case "Femenino"
                    Femenino = 1
                Case "Indifenido"
                    Indefinido = 1
                Case Else
                    Vacio = 1
            End Select
        End If

        If Vacio = 1 Then
            MsgBox("Falta indicar SEXO a alguno de los nombre", MsgBoxStyle.Critical, "Faltan Datos")
            IntervieneOperadorPaso2 = 1
            Exit Sub
        End If

        If Masculino = 1 And Femenino = 1 Then
            MsgBox("Falta definir si el adherente es Masculino o Femenino", MsgBoxStyle.Critical, "FALTA DEFINIR EL SEXO DEL ADHERENTE")
            IntervieneOperadorPaso2 = 1
            Exit Sub
        End If

        If Masculino = 1 And Femenino = 0 Then
            SEXO = "Masculino"
        End If

        If Masculino = 0 And Femenino = 1 Then
            SEXO = "Femenino"
        End If


        If Indefinido = 1 And Femenino = 0 And Masculino = 0 Then
            Dim Mensaje As String
            Dim Decision As String

            Mensaje = "En función que no se sabe indicar si el sexo segun nombre es MASCULINO o FEMENINO" & Chr(10)
            Mensaje += "este NOMBRE no se almacenará en la tabla SEXO, pero se requiere que al adherente se le asigne" & Chr(10)
            Mensaje += "un sexo" & Chr(10) & Chr(10)
            Mensaje += "1 - Masculino" & Chr(10)
            Mensaje += "2 - Femenino"

            Decision = InputBox(Mensaje, "DEFINIR EL SEXO DEL ADHERENTE", "1")

            Select Case Decision
                Case "1"
                    SEXO = "Masculino"
                Case "2"
                    SEXO = "Femenino"
                Case Else
                    IntervieneOperadorPaso2 = 1
            End Select


        End If
    End Sub
    Sub FormarNombreCompuesto()

        NombreAIngresar = Nothing
        If cbo1.Text = "Nombre Compuesto" Then
            NombreAIngresar = Tx1.Text & " "
        End If

        If Cbo2.Text = "Nombre Compuesto" Then
            NombreAIngresar += Tx2.Text & " "
        End If


        If Cbo3.Text = "Nombre Compuesto" Then
            NombreAIngresar += Tx3.Text & " "
        End If


        If Cbo4.Text = "Nombre Compuesto" Then
            NombreAIngresar += Tx4.Text & " "
        End If


        If Cbo5.Text = "Nombre Compuesto" Then
            NombreAIngresar += Tx5.Text & " "
        End If

        'agrupa todos los nombres compuestos en la primera caja de texto y borra las demas
        If cbo1.Text = "Nombre Compuesto" Then
            Tx1.Text = NombreAIngresar
            If Cbo2.Text = "Nombre Compuesto" Then
                Tx2.Text = Nothing
                Cbo2.SelectedIndex = -1
            End If
            If Cbo3.Text = "Nombre Compuesto" Then
                Tx3.Text = Nothing
                Cbo3.SelectedIndex = -1
            End If
            If Cbo4.Text = "Nombre Compuesto" Then
                Tx4.Text = Nothing
                Cbo4.SelectedIndex = -1
            End If
            If Cbo5.Text = "Nombre Compuesto" Then
                Tx5.Text = Nothing
                Cbo5.SelectedIndex = -1
            End If
        End If

        If Cbo2.Text = "Nombre Compuesto" Then
            Tx2.Text = NombreAIngresar
            If Cbo3.Text = "Nombre Compuesto" Then
                Tx3.Text = Nothing
                Cbo3.SelectedIndex = -1
            End If
            If Cbo4.Text = "Nombre Compuesto" Then
                Tx4.Text = Nothing
                Cbo4.SelectedIndex = -1
            End If
            If Cbo5.Text = "Nombre Compuesto" Then
                Tx5.Text = Nothing
                Cbo5.SelectedIndex = -1
            End If
        End If


        If Cbo3.Text = "Nombre Compuesto" Then
            Tx3.Text = NombreAIngresar
            If Cbo4.Text = "Nombre Compuesto" Then
                Tx4.Text = Nothing
                Cbo4.SelectedIndex = -1
            End If
            If Cbo5.Text = "Nombre Compuesto" Then
                Tx5.Text = Nothing
                Cbo5.SelectedIndex = -1
            End If
        End If


        If Cbo4.Text = "Nombre Compuesto" Then
            Tx4.Text = NombreAIngresar
            If Cbo5.Text = "Nombre Compuesto" Then
                Tx5.Text = Nothing
                Cbo5.SelectedIndex = -1
            End If
        End If

        If Cbo5.Text = "Nombre Compuesto" Then
            Tx5.Text = NombreAIngresar
        End If
    End Sub
    Sub SepararApellido_Nombre()

        If NOMBRE = Nothing Then
            Adherente = APELLIDO
            txNombreCompleto.Text = Adherente
            Call DividirNombre()
        Else
            Tx1.Text = APELLIDO
            cbo1.Text = "Apellido"
            Tx2.Text = NOMBRE
            Cbo2.Text = "Nombre"
            CboSexo2.Select()

        End If

    End Sub
    Sub LimpiarControles()
        txCaracter.Text = Nothing
        Tx1.Text = Nothing
        Tx2.Text = Nothing
        Tx3.Text = Nothing
        Tx4.Text = Nothing
        Tx5.Text = Nothing

        cbo1.SelectedIndex = -1
        Cbo2.SelectedIndex = -1
        Cbo3.SelectedIndex = -1
        Cbo4.SelectedIndex = -1
        Cbo5.SelectedIndex = -1

        CboSexo1.SelectedIndex = -1
        CboSexo2.SelectedIndex = -1
        CboSexo3.SelectedIndex = -1
        CboSexo4.SelectedIndex = -1
        CboSexo5.SelectedIndex = -1

        lbID1.Text = Nothing
        lbID2.Text = Nothing
        lbID3.Text = Nothing
        lbID4.Text = Nothing
        lbID5.Text = Nothing

    End Sub
    Sub DividirNombre()
        ' Dim Decision As String
        Dim Posicion As Integer
        Dim SoloUnNombre As Byte
        Dim CantidadVueltas As Byte

        'Call LimpiarControles()
        Call BuscarCaracter()

        Adherente = txNombreCompleto.Text
        Adherente = Trim(Adherente)

        'Ejemplo: Horacio Jose

        While Len(Adherente) > 0 ' la primera vuelta len = 12 , el largo de "horacio Jose"
            CantidadVueltas = CantidadVueltas + 1
            If txCaracter.Text = Nothing Then
                txCaracter.Text = " "
            End If

            Posicion = Adherente.IndexOf(txCaracter.Text) ' busca el espacio entre nombre = 7


            If Posicion > 0 Then ' significa que hay mas de un nombre separado por espacio " "
                NombreABuscar = Adherente.Substring(0, Posicion) 'devuelve Horacio
                Adherente = Adherente.Substring(Posicion + 1) ' se queda con Jose
                Adherente = Trim(Adherente)
            Else
                NombreABuscar = Adherente 'es solo un nombre
                Adherente = Nothing
                SoloUnNombre = 1
            End If


            If Tx1.Text = Nothing Then
                Tx1.Text = NombreABuscar
            ElseIf Tx2.Text = Nothing Then
                Tx2.Text = NombreABuscar
            ElseIf Tx3.Text = Nothing Then
                Tx3.Text = NombreABuscar
            ElseIf Tx4.Text = Nothing Then
                Tx4.Text = NombreABuscar
            ElseIf Tx5.Text = Nothing Then
                Tx5.Text = NombreABuscar
            End If

        End While

        If cbo1.Text = Nothing Then
            cbo1.Select()
        ElseIf Cbo2.Text = Nothing Then
            Cbo2.Select()
        ElseIf Cbo3.Text = Nothing Then
            Cbo3.Select()
        ElseIf Cbo4.Text = Nothing Then
            Cbo4.Select()
        ElseIf Cbo5.Text = Nothing Then
            Cbo5.Select()
        End If

    End Sub
    Sub BuscarCaracter()
        Dim Encontrado As Integer
        Adherente = txNombreCompleto.Text
        Adherente = Trim(Adherente)
        'Ejemplo: Horacio Jose
        'len = 12 , el largo de "horacio Jose"

        Encontrado = Adherente.IndexOf(",") ' busca el espacio entre nombre = 7

        If Encontrado > 0 Then ' esta la coma como separador
            txCaracter.Text = ","
            Exit Sub
        End If

        Encontrado = Adherente.IndexOf(";") ' busca el espacio entre nombre = 7
        If Encontrado > 0 Then ' esta la coma como separador
            txCaracter.Text = ";"
        End If

        Encontrado = Adherente.IndexOf(".") ' busca el espacio entre nombre = 7
        If Encontrado > 0 Then ' esta la coma como separador
            txCaracter.Text = "."
        End If

        txCaracter.Text = " "

    End Sub
    Sub DecidirSeleccionControl()

        If Tx1.Text <> Nothing Then
            If cbo1.Text = Nothing Then
                cbo1.Select()
                Exit Sub
            End If

            If CboSexo1.Text = Nothing And CboSexo1.Visible = True Then
                CboSexo1.Select()
                Exit Sub
            End If
        End If


        If Tx2.Text <> Nothing Then
            If Cbo2.Text = Nothing Then
                Cbo2.Select()
                Exit Sub
            End If

            If CboSexo2.Text = Nothing And CboSexo2.Visible = True Then
                CboSexo2.Select()
                Exit Sub
            End If
        End If

        If Tx3.Text <> Nothing Then
            If Cbo3.Text = Nothing Then
                Cbo3.Select()
                Exit Sub
            End If

            If CboSexo3.Text = Nothing And CboSexo3.Visible = True Then
                CboSexo3.Select()
                Exit Sub
            End If
        End If



        If Tx4.Text <> Nothing Then
            If Cbo4.Text = Nothing Then
                Cbo4.Select()
                Exit Sub
            End If

            If CboSexo4.Text = Nothing And CboSexo4.Visible = True Then
                CboSexo4.Select()
                Exit Sub
            End If
        End If


        If Tx5.Text <> Nothing Then
            If Cbo5.Text = Nothing Then
                Cbo5.Select()
                Exit Sub
            End If

            If CboSexo5.Text = Nothing And CboSexo5.Visible = True Then
                CboSexo5.Select()
                Exit Sub
            End If
        End If

    End Sub


    Private Sub CboSexo1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboSexo1.SelectedIndexChanged
        If Tx1.Text <> Nothing Then
            If CboSexo1.Text <> Nothing Then
                If Tx2.Text <> Nothing Then
                    CboSexo2.Text = CboSexo1.Text
                End If
            End If
        End If
    End Sub

    Private Sub CboSexo2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboSexo2.SelectedIndexChanged
        If Tx2.Text <> Nothing Then
            If CboSexo2.Text <> Nothing Then
                If Tx3.Text <> Nothing Then
                    CboSexo3.Text = CboSexo2.Text
                End If
            End If
        End If
    End Sub

    Private Sub CboSexo3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboSexo3.SelectedIndexChanged
        If Tx3.Text <> Nothing Then
            If CboSexo3.Text <> Nothing Then
                If Tx4.Text <> Nothing Then
                    CboSexo4.Text = CboSexo3.Text
                End If
            End If
        End If
    End Sub

    Private Sub CboSexo4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboSexo4.SelectedIndexChanged
        If Tx4.Text <> Nothing Then
            If CboSexo4.Text <> Nothing Then
                If Tx5.Text <> Nothing Then
                    CboSexo5.Text = CboSexo4.Text
                End If
            End If
        End If
    End Sub

    Private Sub cbo1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo1.SelectedIndexChanged
        If cbo1.Text = "Nombre" Or cbo1.Text = "Nombre Compuesto" Then
            CboSexo1.Visible = True
        Else
            CboSexo1.Visible = False
        End If
    End Sub

    Private Sub Cbo2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cbo2.SelectedIndexChanged
        If Cbo2.Text = "Nombre" Or Cbo2.Text = "Nombre Compuesto" Then
            CboSexo2.Visible = True
        Else
            CboSexo2.Visible = False
        End If
    End Sub

    Private Sub Cbo3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cbo3.SelectedIndexChanged
        If Cbo3.Text = "Nombre" Or Cbo3.Text = "Nombre Compuesto" Then
            CboSexo3.Visible = True
        Else
            CboSexo3.Visible = False
        End If
    End Sub

    Private Sub Cbo4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cbo4.SelectedIndexChanged
        If Cbo4.Text = "Nombre" Or Cbo4.Text = "Nombre Compuesto" Then
            CboSexo4.Visible = True
        Else
            CboSexo4.Visible = False
        End If
    End Sub

    Private Sub Cbo5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cbo5.SelectedIndexChanged
        If Cbo5.Text = "Nombre" Or Cbo5.Text = "Nombre Compuesto" Then
            CboSexo5.Visible = True
        Else
            CboSexo5.Visible = False
        End If
    End Sub

    Private Sub Cbo4_Leave(sender As Object, e As EventArgs) Handles Cbo4.Leave
        If CboSexo4.Visible = False And Tx4.Text = Nothing Then
            btnIngresar.Select()
        End If
    End Sub

    Private Sub Cbo5_Leave(sender As Object, e As EventArgs) Handles Cbo5.Leave
        If CboSexo5.Visible = False And Tx5.Text = Nothing Then
            btnIngresar.Select()
        End If
    End Sub



    Private Sub Cbo2_Leave(sender As Object, e As EventArgs) Handles Cbo2.Leave
        If CboSexo2.Visible = False And Tx2.Text = Nothing Then
            btnIngresar.Select()
        End If
    End Sub

    Private Sub cbo1_Leave(sender As Object, e As EventArgs) Handles cbo1.Leave
        If CboSexo1.Visible = False And Tx1.Text = Nothing Then
            btnIngresar.Select()
        End If
    End Sub

    Private Sub Cbo3_Leave(sender As Object, e As EventArgs) Handles Cbo3.Leave
        If CboSexo3.Visible = False And Tx3.Text = Nothing Then
            btnIngresar.Select()
        End If
    End Sub

    Private Sub btnIngresar_Click(sender As Object, e As EventArgs) Handles btnIngresar.Click
        Call Paso2()
        Call DecidirSeleccionControl()
    End Sub

    Private Sub CboSexo1_Leave(sender As Object, e As EventArgs) Handles CboSexo1.Leave
        If Tx2.Text <> Nothing Then
            If Cbo2.Text = Nothing Then
                Cbo2.Select()
            Else
                CboSexo2.Select()
            End If
        Else
            btnIngresar.Select()
        End If
    End Sub

    Private Sub CboSexo2_Leave(sender As Object, e As EventArgs) Handles CboSexo2.Leave
        If Tx3.Text <> Nothing Then
            If Cbo3.Text = Nothing Then
                Cbo3.Select()
            Else
                CboSexo3.Select()
            End If
        Else
            btnIngresar.Select()
        End If
    End Sub

    Private Sub CboSexo3_Leave(sender As Object, e As EventArgs) Handles CboSexo3.Leave
        If Tx4.Text <> Nothing Then
            If Cbo4.Text = Nothing Then
                Cbo4.Select()
            Else
                CboSexo4.Select()
            End If
        Else
            btnIngresar.Select()
        End If
    End Sub

    Private Sub CboSexo4_Leave(sender As Object, e As EventArgs) Handles CboSexo4.Leave
        If Tx5.Text <> Nothing Then
            If Cbo5.Text <> Nothing Then
                Cbo5.Select()
            Else
                CboSexo5.Select()
            End If
        Else
            btnIngresar.Select()
        End If
    End Sub

    Private Sub CboSexo2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CboSexo2.KeyPress
        If e.KeyChar = Chr(13) Then
            If Tx3.Text <> Nothing Then
                If Cbo3.Text = Nothing Then
                    Cbo3.Select()
                Else
                    CboSexo3.Select()
                End If
            Else
                btnIngresar.Select()
            End If
        End If
    End Sub

    Private Sub CboSexo3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CboSexo3.KeyPress
        If e.KeyChar = Chr(13) Then
            If Tx4.Text <> Nothing Then
                If Cbo4.Text = Nothing Then
                    Cbo4.Select()
                Else
                    CboSexo4.Select()
                End If
            Else
                btnIngresar.Select()
            End If
        End If
    End Sub

    Private Sub EditarApellidoNombreSexoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditarApellidoNombreSexoToolStripMenuItem.Click
        Call CorregirApellidoNombreSexo()
    End Sub



    Private Sub CboSexo4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CboSexo4.KeyPress
        If e.KeyChar = Chr(13) Then
            If Tx5.Text <> Nothing Then
                If Cbo5.Text = Nothing Then
                    Cbo5.Select()
                Else
                    CboSexo5.Select()
                End If
            Else
                btnIngresar.Select()
            End If
        End If
    End Sub

    Private Sub CboSexo5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CboSexo5.KeyPress
        If e.KeyChar = Chr(13) Then
            btnIngresar.Select()
        End If
    End Sub

    Private Sub DataGridBusquedas_Click(sender As Object, e As EventArgs) Handles DataGridBusquedas.Click
        IdAdherente = CLng(DataGridBusquedas.CurrentRow.Cells(0).Value.ToString)
    End Sub



    Sub CorregirApellidoNombreSexo()

        Try
            ConsultaSQL = "SELECT Apellido, Nombre, sexo"
            ConsultaSQL += " From Adherentes where id=" & IdAdherente
            Call Consultar2()
            If dr2.HasRows Then
                dr2.Read()
                APELLIDO = dr2(0).ToString
                NOMBRE = dr2(1).ToString
                SEXO = dr2(2).ToString
            End If

            Tx1.Text = APELLIDO
            Tx2.Text = NOMBRE
            cbo1.Text = "Apellido"
            Cbo2.Text = "Nombre"
            CboSexo2.Text = SEXO
            dr2.Close()

            Call EliminarApellidoDeTablaSexo()
            Call EliminarNombreDeTablaSexo()

        Catch ex As Exception
            MsgBox(ex.Message)
            dr2.Close()
        End Try


    End Sub

    Private Sub FSepararApellidoNombre_Load(sender As Object, e As EventArgs) Handles Me.Load
        btnComenzar.Visible = True
        DataGridBusquedas.DataSource = Nothing
        DataGridBusquedas.Rows.Clear()
        LlegoAFin = 0

    End Sub


End Class