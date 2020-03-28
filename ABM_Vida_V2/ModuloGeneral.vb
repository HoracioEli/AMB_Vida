Module ModuloGeneral
    'fprincipal
    Public EdadMinima, EdadMaxima, EdadPermanencia, SAMinima, SAMaxima As String
    Public FuncionEnProceso, BusquedaGrid As String
    Public TipoContrato As String

    Public RutaPlantilla As String


    'generico
    Public Mensaje As String
    Public RutaPlantillaExcel As String
    Public Contador As Integer
    Public Controlado As Byte
    Public IdAdherente, IdAdherente2 As Integer
    Public Edad As String
    Public AnosAntiguedad As Integer
    Public Origen, Marcado, Accion As String

    'vigentes
    Public IdPolicy, CUIL, APELLIDO, NOMBRE, SEXO, FNACIMIENTO, GRUPO, SUELDO, FINGRESO, SUMAASEGURADA, BENEFICIARIO As String
    Public SueldoAjustado As String

    'actualizado
    Public Documento As String



    'separa apellido nombre sexo
    Public ApellidoAIngresar, NombreAIngresar, SexoAIngresar As String

    Sub LimpiarVariablesRow()
        IdPolicy = Nothing
        CUIL = Nothing
        APELLIDO = Nothing
        NOMBRE = Nothing
        SEXO = Nothing
        FNACIMIENTO = Nothing
        GRUPO = Nothing
        SUELDO = Nothing
        FINGRESO = Nothing
        SUMAASEGURADA = Nothing
        BENEFICIARIO = Nothing
        Documento = Nothing

        SAOriginal = Nothing
        ApellidoNombre = Nothing
        Vigente = Nothing
        Actualizado = Nothing

    End Sub



End Module
