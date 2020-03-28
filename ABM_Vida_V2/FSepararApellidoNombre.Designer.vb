<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FSepararApellidoNombre
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
        Me.DataGridBusquedas = New System.Windows.Forms.DataGridView()
        Me.MnuGrid = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditarApellidoNombreSexoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnIngresar = New System.Windows.Forms.Button()
        Me.btnComenzar = New System.Windows.Forms.Button()
        Me.CboSexo5 = New System.Windows.Forms.ComboBox()
        Me.lbID5 = New System.Windows.Forms.Label()
        Me.CboSexo4 = New System.Windows.Forms.ComboBox()
        Me.lbID4 = New System.Windows.Forms.Label()
        Me.CboSexo3 = New System.Windows.Forms.ComboBox()
        Me.lbID3 = New System.Windows.Forms.Label()
        Me.CboSexo2 = New System.Windows.Forms.ComboBox()
        Me.lbID2 = New System.Windows.Forms.Label()
        Me.CboSexo1 = New System.Windows.Forms.ComboBox()
        Me.lbID1 = New System.Windows.Forms.Label()
        Me.Cbo5 = New System.Windows.Forms.ComboBox()
        Me.Cbo4 = New System.Windows.Forms.ComboBox()
        Me.txNombreCompleto = New System.Windows.Forms.TextBox()
        Me.Cbo3 = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Cbo2 = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbo1 = New System.Windows.Forms.ComboBox()
        Me.txCaracter = New System.Windows.Forms.TextBox()
        Me.Tx5 = New System.Windows.Forms.TextBox()
        Me.Tx1 = New System.Windows.Forms.TextBox()
        Me.Tx4 = New System.Windows.Forms.TextBox()
        Me.Tx2 = New System.Windows.Forms.TextBox()
        Me.Tx3 = New System.Windows.Forms.TextBox()
        CType(Me.DataGridBusquedas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MnuGrid.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridBusquedas
        '
        Me.DataGridBusquedas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridBusquedas.ContextMenuStrip = Me.MnuGrid
        Me.DataGridBusquedas.Location = New System.Drawing.Point(43, 213)
        Me.DataGridBusquedas.Name = "DataGridBusquedas"
        Me.DataGridBusquedas.Size = New System.Drawing.Size(425, 204)
        Me.DataGridBusquedas.TabIndex = 67
        '
        'MnuGrid
        '
        Me.MnuGrid.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditarApellidoNombreSexoToolStripMenuItem})
        Me.MnuGrid.Name = "MnuGrid"
        Me.MnuGrid.Size = New System.Drawing.Size(236, 26)
        '
        'EditarApellidoNombreSexoToolStripMenuItem
        '
        Me.EditarApellidoNombreSexoToolStripMenuItem.Name = "EditarApellidoNombreSexoToolStripMenuItem"
        Me.EditarApellidoNombreSexoToolStripMenuItem.Size = New System.Drawing.Size(235, 22)
        Me.EditarApellidoNombreSexoToolStripMenuItem.Text = "·Editar Apellido, Nombre, Sexo"
        '
        'btnIngresar
        '
        Me.btnIngresar.BackColor = System.Drawing.Color.Black
        Me.btnIngresar.ForeColor = System.Drawing.Color.White
        Me.btnIngresar.Location = New System.Drawing.Point(43, 178)
        Me.btnIngresar.Name = "btnIngresar"
        Me.btnIngresar.Size = New System.Drawing.Size(425, 28)
        Me.btnIngresar.TabIndex = 65
        Me.btnIngresar.Text = "Ingresar"
        Me.btnIngresar.UseVisualStyleBackColor = False
        '
        'btnComenzar
        '
        Me.btnComenzar.BackColor = System.Drawing.Color.Black
        Me.btnComenzar.ForeColor = System.Drawing.Color.White
        Me.btnComenzar.Location = New System.Drawing.Point(487, 363)
        Me.btnComenzar.Name = "btnComenzar"
        Me.btnComenzar.Size = New System.Drawing.Size(161, 54)
        Me.btnComenzar.TabIndex = 66
        Me.btnComenzar.Text = "Comenzar"
        Me.btnComenzar.UseVisualStyleBackColor = False
        '
        'CboSexo5
        '
        Me.CboSexo5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboSexo5.FormattingEnabled = True
        Me.CboSexo5.Items.AddRange(New Object() {"Femenino", "Masculino", "Indefinido"})
        Me.CboSexo5.Location = New System.Drawing.Point(366, 139)
        Me.CboSexo5.Name = "CboSexo5"
        Me.CboSexo5.Size = New System.Drawing.Size(102, 21)
        Me.CboSexo5.TabIndex = 64
        Me.CboSexo5.Visible = False
        '
        'lbID5
        '
        Me.lbID5.AutoSize = True
        Me.lbID5.BackColor = System.Drawing.Color.Silver
        Me.lbID5.Location = New System.Drawing.Point(474, 143)
        Me.lbID5.Name = "lbID5"
        Me.lbID5.Size = New System.Drawing.Size(0, 13)
        Me.lbID5.TabIndex = 49
        '
        'CboSexo4
        '
        Me.CboSexo4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboSexo4.FormattingEnabled = True
        Me.CboSexo4.Items.AddRange(New Object() {"Femenino", "Masculino", "Indefinido"})
        Me.CboSexo4.Location = New System.Drawing.Point(366, 119)
        Me.CboSexo4.Name = "CboSexo4"
        Me.CboSexo4.Size = New System.Drawing.Size(102, 21)
        Me.CboSexo4.TabIndex = 61
        Me.CboSexo4.Visible = False
        '
        'lbID4
        '
        Me.lbID4.AutoSize = True
        Me.lbID4.BackColor = System.Drawing.Color.Silver
        Me.lbID4.Location = New System.Drawing.Point(474, 122)
        Me.lbID4.Name = "lbID4"
        Me.lbID4.Size = New System.Drawing.Size(0, 13)
        Me.lbID4.TabIndex = 48
        '
        'CboSexo3
        '
        Me.CboSexo3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboSexo3.FormattingEnabled = True
        Me.CboSexo3.Items.AddRange(New Object() {"Femenino", "Masculino", "Indefinido"})
        Me.CboSexo3.Location = New System.Drawing.Point(366, 99)
        Me.CboSexo3.Name = "CboSexo3"
        Me.CboSexo3.Size = New System.Drawing.Size(102, 21)
        Me.CboSexo3.TabIndex = 58
        Me.CboSexo3.Visible = False
        '
        'lbID3
        '
        Me.lbID3.AutoSize = True
        Me.lbID3.BackColor = System.Drawing.Color.Silver
        Me.lbID3.Location = New System.Drawing.Point(474, 103)
        Me.lbID3.Name = "lbID3"
        Me.lbID3.Size = New System.Drawing.Size(0, 13)
        Me.lbID3.TabIndex = 47
        '
        'CboSexo2
        '
        Me.CboSexo2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboSexo2.FormattingEnabled = True
        Me.CboSexo2.Items.AddRange(New Object() {"Femenino", "Masculino", "Indefinido"})
        Me.CboSexo2.Location = New System.Drawing.Point(366, 80)
        Me.CboSexo2.Name = "CboSexo2"
        Me.CboSexo2.Size = New System.Drawing.Size(102, 21)
        Me.CboSexo2.TabIndex = 55
        Me.CboSexo2.Visible = False
        '
        'lbID2
        '
        Me.lbID2.AutoSize = True
        Me.lbID2.BackColor = System.Drawing.Color.Silver
        Me.lbID2.Location = New System.Drawing.Point(474, 83)
        Me.lbID2.Name = "lbID2"
        Me.lbID2.Size = New System.Drawing.Size(0, 13)
        Me.lbID2.TabIndex = 46
        '
        'CboSexo1
        '
        Me.CboSexo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboSexo1.FormattingEnabled = True
        Me.CboSexo1.Items.AddRange(New Object() {"Femenino", "Masculino", "Indefinido"})
        Me.CboSexo1.Location = New System.Drawing.Point(366, 59)
        Me.CboSexo1.Name = "CboSexo1"
        Me.CboSexo1.Size = New System.Drawing.Size(102, 21)
        Me.CboSexo1.TabIndex = 52
        Me.CboSexo1.Visible = False
        '
        'lbID1
        '
        Me.lbID1.AutoSize = True
        Me.lbID1.BackColor = System.Drawing.Color.Silver
        Me.lbID1.Location = New System.Drawing.Point(474, 62)
        Me.lbID1.Name = "lbID1"
        Me.lbID1.Size = New System.Drawing.Size(0, 13)
        Me.lbID1.TabIndex = 45
        '
        'Cbo5
        '
        Me.Cbo5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cbo5.FormattingEnabled = True
        Me.Cbo5.Items.AddRange(New Object() {"Apellido", "Nombre", "Nombre Compuesto"})
        Me.Cbo5.Location = New System.Drawing.Point(247, 139)
        Me.Cbo5.Name = "Cbo5"
        Me.Cbo5.Size = New System.Drawing.Size(118, 21)
        Me.Cbo5.TabIndex = 63
        '
        'Cbo4
        '
        Me.Cbo4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cbo4.FormattingEnabled = True
        Me.Cbo4.Items.AddRange(New Object() {"Apellido", "Nombre", "Nombre Compuesto"})
        Me.Cbo4.Location = New System.Drawing.Point(247, 119)
        Me.Cbo4.Name = "Cbo4"
        Me.Cbo4.Size = New System.Drawing.Size(118, 21)
        Me.Cbo4.TabIndex = 60
        '
        'txNombreCompleto
        '
        Me.txNombreCompleto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txNombreCompleto.Location = New System.Drawing.Point(43, 23)
        Me.txNombreCompleto.Name = "txNombreCompleto"
        Me.txNombreCompleto.Size = New System.Drawing.Size(376, 20)
        Me.txNombreCompleto.TabIndex = 41
        '
        'Cbo3
        '
        Me.Cbo3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cbo3.FormattingEnabled = True
        Me.Cbo3.Items.AddRange(New Object() {"Apellido", "Nombre", "Nombre Compuesto"})
        Me.Cbo3.Location = New System.Drawing.Point(247, 99)
        Me.Cbo3.Name = "Cbo3"
        Me.Cbo3.Size = New System.Drawing.Size(118, 21)
        Me.Cbo3.TabIndex = 57
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(40, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(139, 13)
        Me.Label1.TabIndex = 43
        Me.Label1.Text = "Apellido y Nombre Completo"
        '
        'Cbo2
        '
        Me.Cbo2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cbo2.FormattingEnabled = True
        Me.Cbo2.Items.AddRange(New Object() {"Apellido", "Nombre", "Nombre Compuesto"})
        Me.Cbo2.Location = New System.Drawing.Point(247, 80)
        Me.Cbo2.Name = "Cbo2"
        Me.Cbo2.Size = New System.Drawing.Size(118, 21)
        Me.Cbo2.TabIndex = 54
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(407, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 44
        Me.Label2.Text = "Separación"
        '
        'cbo1
        '
        Me.cbo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo1.FormattingEnabled = True
        Me.cbo1.Items.AddRange(New Object() {"Apellido", "Nombre", "Nombre Compuesto"})
        Me.cbo1.Location = New System.Drawing.Point(247, 59)
        Me.cbo1.Name = "cbo1"
        Me.cbo1.Size = New System.Drawing.Size(118, 21)
        Me.cbo1.TabIndex = 51
        '
        'txCaracter
        '
        Me.txCaracter.Location = New System.Drawing.Point(425, 23)
        Me.txCaracter.Name = "txCaracter"
        Me.txCaracter.Size = New System.Drawing.Size(43, 20)
        Me.txCaracter.TabIndex = 42
        Me.txCaracter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Tx5
        '
        Me.Tx5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Tx5.Location = New System.Drawing.Point(43, 140)
        Me.Tx5.Name = "Tx5"
        Me.Tx5.Size = New System.Drawing.Size(203, 20)
        Me.Tx5.TabIndex = 62
        Me.Tx5.TabStop = False
        '
        'Tx1
        '
        Me.Tx1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Tx1.Location = New System.Drawing.Point(43, 60)
        Me.Tx1.Name = "Tx1"
        Me.Tx1.Size = New System.Drawing.Size(203, 20)
        Me.Tx1.TabIndex = 50
        Me.Tx1.TabStop = False
        '
        'Tx4
        '
        Me.Tx4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Tx4.Location = New System.Drawing.Point(43, 120)
        Me.Tx4.Name = "Tx4"
        Me.Tx4.Size = New System.Drawing.Size(203, 20)
        Me.Tx4.TabIndex = 59
        Me.Tx4.TabStop = False
        '
        'Tx2
        '
        Me.Tx2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Tx2.Location = New System.Drawing.Point(43, 80)
        Me.Tx2.Name = "Tx2"
        Me.Tx2.Size = New System.Drawing.Size(203, 20)
        Me.Tx2.TabIndex = 53
        Me.Tx2.TabStop = False
        '
        'Tx3
        '
        Me.Tx3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Tx3.Location = New System.Drawing.Point(43, 100)
        Me.Tx3.Name = "Tx3"
        Me.Tx3.Size = New System.Drawing.Size(203, 20)
        Me.Tx3.TabIndex = 56
        Me.Tx3.TabStop = False
        '
        'FSepararApellidoNombre
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.RoyalBlue
        Me.ClientSize = New System.Drawing.Size(683, 441)
        Me.Controls.Add(Me.DataGridBusquedas)
        Me.Controls.Add(Me.btnIngresar)
        Me.Controls.Add(Me.btnComenzar)
        Me.Controls.Add(Me.CboSexo5)
        Me.Controls.Add(Me.lbID5)
        Me.Controls.Add(Me.CboSexo4)
        Me.Controls.Add(Me.lbID4)
        Me.Controls.Add(Me.CboSexo3)
        Me.Controls.Add(Me.lbID3)
        Me.Controls.Add(Me.CboSexo2)
        Me.Controls.Add(Me.lbID2)
        Me.Controls.Add(Me.CboSexo1)
        Me.Controls.Add(Me.lbID1)
        Me.Controls.Add(Me.Cbo5)
        Me.Controls.Add(Me.Cbo4)
        Me.Controls.Add(Me.txNombreCompleto)
        Me.Controls.Add(Me.Cbo3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Cbo2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbo1)
        Me.Controls.Add(Me.txCaracter)
        Me.Controls.Add(Me.Tx5)
        Me.Controls.Add(Me.Tx1)
        Me.Controls.Add(Me.Tx4)
        Me.Controls.Add(Me.Tx2)
        Me.Controls.Add(Me.Tx3)
        Me.Name = "FSepararApellidoNombre"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Separa Apellido, Nombre y establecer Sexo"
        CType(Me.DataGridBusquedas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MnuGrid.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridBusquedas As DataGridView
    Friend WithEvents btnIngresar As Button
    Friend WithEvents btnComenzar As Button
    Friend WithEvents CboSexo5 As ComboBox
    Friend WithEvents lbID5 As Label
    Friend WithEvents CboSexo4 As ComboBox
    Friend WithEvents lbID4 As Label
    Friend WithEvents CboSexo3 As ComboBox
    Friend WithEvents lbID3 As Label
    Friend WithEvents CboSexo2 As ComboBox
    Friend WithEvents lbID2 As Label
    Friend WithEvents CboSexo1 As ComboBox
    Friend WithEvents lbID1 As Label
    Friend WithEvents Cbo5 As ComboBox
    Friend WithEvents Cbo4 As ComboBox
    Friend WithEvents txNombreCompleto As TextBox
    Friend WithEvents Cbo3 As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Cbo2 As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cbo1 As ComboBox
    Friend WithEvents txCaracter As TextBox
    Friend WithEvents Tx5 As TextBox
    Friend WithEvents Tx1 As TextBox
    Friend WithEvents Tx4 As TextBox
    Friend WithEvents Tx2 As TextBox
    Friend WithEvents Tx3 As TextBox
    Friend WithEvents MnuGrid As ContextMenuStrip
    Friend WithEvents EditarApellidoNombreSexoToolStripMenuItem As ToolStripMenuItem
End Class
