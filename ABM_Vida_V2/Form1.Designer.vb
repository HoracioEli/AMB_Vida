<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FPrincipal
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CboTipoContrato = New System.Windows.Forms.ComboBox()
        Me.GpoVariables = New System.Windows.Forms.GroupBox()
        Me.txEdadPermanencia = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxSAMaxima = New System.Windows.Forms.TextBox()
        Me.TxSAMinima = New System.Windows.Forms.TextBox()
        Me.TxEdadMaxima = New System.Windows.Forms.TextBox()
        Me.TxEdadMinima = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnPaso1_ImportarVigentes = New System.Windows.Forms.Button()
        Me.LbRutaPlantillaExcel = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.btnActualizar = New System.Windows.Forms.Button()
        Me.btnBajas = New System.Windows.Forms.Button()
        Me.btnAltas = New System.Windows.Forms.Button()
        Me.btn2_ImportarActualizado = New System.Windows.Forms.Button()
        Me.btnPaso3_ApellidoNombreSexo = New System.Windows.Forms.Button()
        Me.btnPaso4_EditarCUIL_SA_Antiguedad = New System.Windows.Forms.Button()
        Me.btnPaso5_PrepararExcel = New System.Windows.Forms.Button()
        Me.DataGridBusquedas = New System.Windows.Forms.DataGridView()
        Me.CMGrilla = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.VerRepetidosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VerEliminadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VerAgregadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VerListadoActualizadoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnPaso6_ExportarAExcel = New System.Windows.Forms.Button()
        Me.VerListadoCompletoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GpoVariables.SuspendLayout()
        CType(Me.DataGridBusquedas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMGrilla.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(34, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 13)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "Tipo Contrato"
        '
        'CboTipoContrato
        '
        Me.CboTipoContrato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboTipoContrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboTipoContrato.FormattingEnabled = True
        Me.CboTipoContrato.Location = New System.Drawing.Point(37, 26)
        Me.CboTipoContrato.Name = "CboTipoContrato"
        Me.CboTipoContrato.Size = New System.Drawing.Size(277, 24)
        Me.CboTipoContrato.TabIndex = 46
        '
        'GpoVariables
        '
        Me.GpoVariables.Controls.Add(Me.txEdadPermanencia)
        Me.GpoVariables.Controls.Add(Me.Label6)
        Me.GpoVariables.Controls.Add(Me.TxSAMaxima)
        Me.GpoVariables.Controls.Add(Me.TxSAMinima)
        Me.GpoVariables.Controls.Add(Me.TxEdadMaxima)
        Me.GpoVariables.Controls.Add(Me.TxEdadMinima)
        Me.GpoVariables.Controls.Add(Me.Label5)
        Me.GpoVariables.Controls.Add(Me.Label4)
        Me.GpoVariables.Controls.Add(Me.Label3)
        Me.GpoVariables.Controls.Add(Me.Label2)
        Me.GpoVariables.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GpoVariables.ForeColor = System.Drawing.Color.Yellow
        Me.GpoVariables.Location = New System.Drawing.Point(366, 14)
        Me.GpoVariables.Name = "GpoVariables"
        Me.GpoVariables.Size = New System.Drawing.Size(785, 128)
        Me.GpoVariables.TabIndex = 48
        Me.GpoVariables.TabStop = False
        Me.GpoVariables.Text = "Variables"
        '
        'txEdadPermanencia
        '
        Me.txEdadPermanencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txEdadPermanencia.Location = New System.Drawing.Point(165, 88)
        Me.txEdadPermanencia.Name = "txEdadPermanencia"
        Me.txEdadPermanencia.Size = New System.Drawing.Size(100, 22)
        Me.txEdadPermanencia.TabIndex = 2
        Me.txEdadPermanencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(18, 93)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(136, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Edad Máxima Permanencia"
        '
        'TxSAMaxima
        '
        Me.TxSAMaxima.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxSAMaxima.Location = New System.Drawing.Point(630, 59)
        Me.TxSAMaxima.Name = "TxSAMaxima"
        Me.TxSAMaxima.Size = New System.Drawing.Size(100, 22)
        Me.TxSAMaxima.TabIndex = 4
        Me.TxSAMaxima.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxSAMinima
        '
        Me.TxSAMinima.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxSAMinima.Location = New System.Drawing.Point(630, 22)
        Me.TxSAMinima.Name = "TxSAMinima"
        Me.TxSAMinima.Size = New System.Drawing.Size(100, 22)
        Me.TxSAMinima.TabIndex = 3
        Me.TxSAMinima.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxEdadMaxima
        '
        Me.TxEdadMaxima.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxEdadMaxima.Location = New System.Drawing.Point(165, 52)
        Me.TxEdadMaxima.Name = "TxEdadMaxima"
        Me.TxEdadMaxima.Size = New System.Drawing.Size(100, 22)
        Me.TxEdadMaxima.TabIndex = 1
        Me.TxEdadMaxima.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxEdadMinima
        '
        Me.TxEdadMinima.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxEdadMinima.Location = New System.Drawing.Point(165, 26)
        Me.TxEdadMinima.Name = "TxEdadMinima"
        Me.TxEdadMinima.Size = New System.Drawing.Size(100, 22)
        Me.TxEdadMinima.TabIndex = 0
        Me.TxEdadMinima.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(486, 66)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(127, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Suma Asegurada Máxima"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(486, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(126, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Suma Asegurada Mínima"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Edad Máxima"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Edad Minima"
        '
        'btnPaso1_ImportarVigentes
        '
        Me.btnPaso1_ImportarVigentes.Location = New System.Drawing.Point(34, 78)
        Me.btnPaso1_ImportarVigentes.Name = "btnPaso1_ImportarVigentes"
        Me.btnPaso1_ImportarVigentes.Size = New System.Drawing.Size(280, 64)
        Me.btnPaso1_ImportarVigentes.TabIndex = 49
        Me.btnPaso1_ImportarVigentes.Text = "Paso 1 - Buscar Archivo Exportado PC (Vigentes)"
        Me.btnPaso1_ImportarVigentes.UseVisualStyleBackColor = True
        '
        'LbRutaPlantillaExcel
        '
        Me.LbRutaPlantillaExcel.ForeColor = System.Drawing.Color.White
        Me.LbRutaPlantillaExcel.Location = New System.Drawing.Point(37, 57)
        Me.LbRutaPlantillaExcel.Name = "LbRutaPlantillaExcel"
        Me.LbRutaPlantillaExcel.Size = New System.Drawing.Size(280, 19)
        Me.LbRutaPlantillaExcel.TabIndex = 50
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'btnActualizar
        '
        Me.btnActualizar.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnActualizar.ForeColor = System.Drawing.Color.White
        Me.btnActualizar.Location = New System.Drawing.Point(34, 162)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(90, 64)
        Me.btnActualizar.TabIndex = 51
        Me.btnActualizar.Text = "Actualizar"
        Me.btnActualizar.UseVisualStyleBackColor = False
        '
        'btnBajas
        '
        Me.btnBajas.BackColor = System.Drawing.Color.Red
        Me.btnBajas.ForeColor = System.Drawing.Color.White
        Me.btnBajas.Location = New System.Drawing.Point(224, 162)
        Me.btnBajas.Name = "btnBajas"
        Me.btnBajas.Size = New System.Drawing.Size(90, 64)
        Me.btnBajas.TabIndex = 52
        Me.btnBajas.Text = "Bajas"
        Me.btnBajas.UseVisualStyleBackColor = False
        '
        'btnAltas
        '
        Me.btnAltas.BackColor = System.Drawing.Color.ForestGreen
        Me.btnAltas.ForeColor = System.Drawing.Color.White
        Me.btnAltas.Location = New System.Drawing.Point(130, 162)
        Me.btnAltas.Name = "btnAltas"
        Me.btnAltas.Size = New System.Drawing.Size(90, 64)
        Me.btnAltas.TabIndex = 53
        Me.btnAltas.Text = "Altas"
        Me.btnAltas.UseVisualStyleBackColor = False
        '
        'btn2_ImportarActualizado
        '
        Me.btn2_ImportarActualizado.Location = New System.Drawing.Point(34, 258)
        Me.btn2_ImportarActualizado.Name = "btn2_ImportarActualizado"
        Me.btn2_ImportarActualizado.Size = New System.Drawing.Size(280, 64)
        Me.btn2_ImportarActualizado.TabIndex = 54
        Me.btn2_ImportarActualizado.Text = "Paso 2 - Buscar Plantilla Recien Generada"
        Me.btn2_ImportarActualizado.UseVisualStyleBackColor = True
        '
        'btnPaso3_ApellidoNombreSexo
        '
        Me.btnPaso3_ApellidoNombreSexo.Location = New System.Drawing.Point(34, 328)
        Me.btnPaso3_ApellidoNombreSexo.Name = "btnPaso3_ApellidoNombreSexo"
        Me.btnPaso3_ApellidoNombreSexo.Size = New System.Drawing.Size(280, 64)
        Me.btnPaso3_ApellidoNombreSexo.TabIndex = 55
        Me.btnPaso3_ApellidoNombreSexo.Text = "Paso 3 - Editar Apellido, Nombre y Sexo"
        Me.btnPaso3_ApellidoNombreSexo.UseVisualStyleBackColor = True
        '
        'btnPaso4_EditarCUIL_SA_Antiguedad
        '
        Me.btnPaso4_EditarCUIL_SA_Antiguedad.Location = New System.Drawing.Point(34, 398)
        Me.btnPaso4_EditarCUIL_SA_Antiguedad.Name = "btnPaso4_EditarCUIL_SA_Antiguedad"
        Me.btnPaso4_EditarCUIL_SA_Antiguedad.Size = New System.Drawing.Size(280, 64)
        Me.btnPaso4_EditarCUIL_SA_Antiguedad.TabIndex = 56
        Me.btnPaso4_EditarCUIL_SA_Antiguedad.Text = "Paso 4 - Editar CUIL, SA, ANTIGUEDAD"
        Me.btnPaso4_EditarCUIL_SA_Antiguedad.UseVisualStyleBackColor = True
        '
        'btnPaso5_PrepararExcel
        '
        Me.btnPaso5_PrepararExcel.Location = New System.Drawing.Point(34, 468)
        Me.btnPaso5_PrepararExcel.Name = "btnPaso5_PrepararExcel"
        Me.btnPaso5_PrepararExcel.Size = New System.Drawing.Size(280, 64)
        Me.btnPaso5_PrepararExcel.TabIndex = 57
        Me.btnPaso5_PrepararExcel.Text = "Paso 5 - Preparar Excel para Exportar"
        Me.btnPaso5_PrepararExcel.UseVisualStyleBackColor = True
        '
        'DataGridBusquedas
        '
        Me.DataGridBusquedas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridBusquedas.ContextMenuStrip = Me.CMGrilla
        Me.DataGridBusquedas.Location = New System.Drawing.Point(357, 162)
        Me.DataGridBusquedas.Name = "DataGridBusquedas"
        Me.DataGridBusquedas.Size = New System.Drawing.Size(794, 439)
        Me.DataGridBusquedas.TabIndex = 68
        '
        'CMGrilla
        '
        Me.CMGrilla.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VerRepetidosToolStripMenuItem, Me.VerEliminadosToolStripMenuItem, Me.VerAgregadosToolStripMenuItem, Me.VerListadoActualizadoToolStripMenuItem, Me.VerListadoCompletoToolStripMenuItem})
        Me.CMGrilla.Name = "CMGrilla"
        Me.CMGrilla.Size = New System.Drawing.Size(197, 136)
        '
        'VerRepetidosToolStripMenuItem
        '
        Me.VerRepetidosToolStripMenuItem.Name = "VerRepetidosToolStripMenuItem"
        Me.VerRepetidosToolStripMenuItem.Size = New System.Drawing.Size(196, 22)
        Me.VerRepetidosToolStripMenuItem.Text = "Ver Repetidos"
        '
        'VerEliminadosToolStripMenuItem
        '
        Me.VerEliminadosToolStripMenuItem.Name = "VerEliminadosToolStripMenuItem"
        Me.VerEliminadosToolStripMenuItem.Size = New System.Drawing.Size(196, 22)
        Me.VerEliminadosToolStripMenuItem.Text = "Ver Eliminados"
        '
        'VerAgregadosToolStripMenuItem
        '
        Me.VerAgregadosToolStripMenuItem.Name = "VerAgregadosToolStripMenuItem"
        Me.VerAgregadosToolStripMenuItem.Size = New System.Drawing.Size(196, 22)
        Me.VerAgregadosToolStripMenuItem.Text = "Ver Agregados"
        '
        'VerListadoActualizadoToolStripMenuItem
        '
        Me.VerListadoActualizadoToolStripMenuItem.Name = "VerListadoActualizadoToolStripMenuItem"
        Me.VerListadoActualizadoToolStripMenuItem.Size = New System.Drawing.Size(196, 22)
        Me.VerListadoActualizadoToolStripMenuItem.Text = "Ver Listado Actualizado"
        '
        'btnPaso6_ExportarAExcel
        '
        Me.btnPaso6_ExportarAExcel.Location = New System.Drawing.Point(34, 538)
        Me.btnPaso6_ExportarAExcel.Name = "btnPaso6_ExportarAExcel"
        Me.btnPaso6_ExportarAExcel.Size = New System.Drawing.Size(280, 64)
        Me.btnPaso6_ExportarAExcel.TabIndex = 69
        Me.btnPaso6_ExportarAExcel.Text = "Paso 6 - Exportar a Excel"
        Me.btnPaso6_ExportarAExcel.UseVisualStyleBackColor = True
        '
        'VerListadoCompletoToolStripMenuItem
        '
        Me.VerListadoCompletoToolStripMenuItem.Name = "VerListadoCompletoToolStripMenuItem"
        Me.VerListadoCompletoToolStripMenuItem.Size = New System.Drawing.Size(196, 22)
        Me.VerListadoCompletoToolStripMenuItem.Text = "Ver Listado Completo"
        '
        'FPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.MidnightBlue
        Me.ClientSize = New System.Drawing.Size(1213, 629)
        Me.Controls.Add(Me.btnPaso6_ExportarAExcel)
        Me.Controls.Add(Me.DataGridBusquedas)
        Me.Controls.Add(Me.btnPaso5_PrepararExcel)
        Me.Controls.Add(Me.btnPaso4_EditarCUIL_SA_Antiguedad)
        Me.Controls.Add(Me.btnPaso3_ApellidoNombreSexo)
        Me.Controls.Add(Me.btn2_ImportarActualizado)
        Me.Controls.Add(Me.btnAltas)
        Me.Controls.Add(Me.btnBajas)
        Me.Controls.Add(Me.btnActualizar)
        Me.Controls.Add(Me.LbRutaPlantillaExcel)
        Me.Controls.Add(Me.btnPaso1_ImportarVigentes)
        Me.Controls.Add(Me.GpoVariables)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CboTipoContrato)
        Me.Name = "FPrincipal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Movimientos Vida Colectivo Policy"
        Me.GpoVariables.ResumeLayout(False)
        Me.GpoVariables.PerformLayout()
        CType(Me.DataGridBusquedas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMGrilla.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents CboTipoContrato As ComboBox
    Friend WithEvents GpoVariables As GroupBox
    Friend WithEvents txEdadPermanencia As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TxSAMaxima As TextBox
    Friend WithEvents TxSAMinima As TextBox
    Friend WithEvents TxEdadMaxima As TextBox
    Friend WithEvents TxEdadMinima As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnPaso1_ImportarVigentes As Button
    Friend WithEvents LbRutaPlantillaExcel As Label
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents btnActualizar As Button
    Friend WithEvents btnBajas As Button
    Friend WithEvents btnAltas As Button
    Friend WithEvents btn2_ImportarActualizado As Button
    Friend WithEvents btnPaso3_ApellidoNombreSexo As Button
    Friend WithEvents btnPaso4_EditarCUIL_SA_Antiguedad As Button
    Friend WithEvents btnPaso5_PrepararExcel As Button
    Friend WithEvents DataGridBusquedas As DataGridView
    Friend WithEvents CMGrilla As ContextMenuStrip
    Friend WithEvents VerRepetidosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VerEliminadosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VerAgregadosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VerListadoActualizadoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnPaso6_ExportarAExcel As Button
    Friend WithEvents VerListadoCompletoToolStripMenuItem As ToolStripMenuItem
End Class
