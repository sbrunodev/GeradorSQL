   M S B A M L   `   `   `  ����  
GeradorSQL    GeradorSQL.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          �Name$  
frmGerador��5   	    � Title$ 
GeradorSQL��5   	   $��685.525��6   $��1124.81��6.    � 
ResizeMode$ NoResize=�6>    � WindowStartupLocation$ Manual=�6o    � Icon$ 	icon-.ico��6�   $��Visible=�6�   .��5      � $��0,0,-218,-272q�6   .+�5   
   �� $��
GeradorSQL��6   $
��Left=�6%   $��	34,27,0,0q�6@   $	��Top=�6S   $��20(�6k   �� 5   
   -   5         ��Name$ 	btnSubmit��5      $��GerarSQL - F3��6$   $
��Left=�6<   $��439,568,0,0q�6W   $	��Top=�6l   $��83��6�   $��45��6�   6�   �� 5   
   $��Nome da Tabela��6   $
��Left=�6)   $��	31,63,0,0q�6D   $	��Top=�6W   $��13(�6o   �� 5	   
   -   5         ��Name$ ttbNomeTabela��5	      $
��Left=�6)   $��23��6D   $��
135,66,0,0q�6P    �� TextWrapping$
 Wrap=�6d   $�� ��6x   $	��Top=�6�   $	��120��6�   $��13(�6�   $��1��6�   6�   �� 5
   
   $��Nome da Coluna��6   $
��Left=�6)   $��
53,121,0,0q�6D   $	��Top=�6X   $��13(�6p   �� 5   
   -   5        $ ttbNomeCampo��5      $
��Left=�6(   $��23��6C   $��169,121,0,0q�6O   $
 Wrap=�6d   $�� ��6x   $	��Top=�6�   $	��120��6�   $��13(�6�   $��2��6�   6�   �� 5   
   -   5        $ 
btnInserir��5      $��Inserir - F1��6%   $
��Left=�6<   $��417,165,0,0q�6W   $	��Top=�6l   $��83��6�   $��45��6�   $��4��6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgvBanco��5   k   	   AutoGenerateColumns	 .  $	��292��6/   $
��Left=�6<   $��
34,256,0,0q�6W   $	��Top=�6}   $	��488��6�   
   
IsReadOnly
 . ���	#FF678099$��14(�6�      HorizontalGridLinesBrush
 �   � �� AlternationCount$ 2��6     RowBackground �	#FFBBBFF5   AlternatingRowBackground
 ��������	#FFF1F1F1 � ToolTip$9 3Para alterar use o Double Click na linha desejada! ��5   �   ��5   �   ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 30 6%      Header$  ��6K   1  +System.Windows.Controls.DataGridBoundColumn   Binding 60   �� *codigo+6K     5      $	 150 6%   $ Coluna��6J    61   �� *nome+6J     5      $	 150 6%   $ Atributo��6N    61   �� *
atributo+6N     5      $	 150 6%   $
 Tipo��6J    61   �� *tipo+6J   5      �� 5   
   -   5         ��Name$ 	cbUtiliza��5      $3��-Utilizar o mesmo nome do banco para a Classe?��6&   $
��Left=�6^   $��
68,165,0,0q�6y   $	��Top=�6�   $��13(�6�   6�   �� 5   
   $B��<Campos referentes a coluna do Banco e os atributos da Classe��6   $
��Left=�6W   $��
29,225,0,0q�6r   $	��Top=�6�   $��13(�6�   �� 5   
   -   5         ��Name$ lblAtributo��5      $��Nome do Atributo��6%   $
��Left=�6@   $��
53,165,0,0q�6[   $	��Top=�6o   $��13(�6�   �� 5   
   -	   5        $ ttbNomeCampoAtributo��5      $
��Left=�60   $��23��6K   $��169,165,0,0q�6W   $
 Wrap=�6l   $�� ��6�   $	��Top=�6�   $	��120��6�   $��13(�6�   $��3��6�   �� 5   
   -
   5         ��Name$ rtbCodigoSQL��5      $
��Left=�6,   $	��547��6G   $��
585,66,0,0q�6T   $	��Top=�6h   $	��492��6�   $��14(�6�   " �� VerticalScrollBarVisibility$ Visible=�6�   . �5      /� .T�5      J� .*�6   .*�5      �� $� ��6   5       5!      5"      �� 5#   
   ���	#FF8787FF$
��Left=�6%   $��9��6@   
���   �$	��Top=�6Z   $
��1280��6r   $��0,1,0,0q�6   �� 5$   
   $��*��6   $
��Left=�6   $��294,121,0,0q�67   $	��Top=�6L   $V PAtenção, é importante que o primeiro  campo a ser inserido seja a Primary Key��6d   
���  ��6�   �� 5%   
   -   5        $ 
btnRetirar��5%      $��Retirar - F2��6%   $
��Left=�6<   $��
34,568,0,0q�6W   $	��Top=�6k   $��83��6�   $��45��6�   $��4��6�   $- 'Selecione uma Linha e Precisone Retirar��6�   �� 5&   
   $��Nome da Classe��6   $
��Left=�6)   $��
276,63,0,0q�6D   $	��Top=�6X   $��13(�6p   �� 5'   
   -   5        $ ttbNomeClasse��5'      $
��Left=�6)   $��23��6D   $��
380,66,0,0q�6P   $
 Wrap=�6d   $�� ��6x   $	��Top=�6�   $	��120��6�   $��13(�6�   $��1��6�   �� 5(   
   -   5         ��Name$ cbbTipo��5(      $
��Left=�6$   $��380,121,0,0q�6?   $	��Top=�6T   $	��120��6l   $��23��6x   �� 5)   
   $
��Tipo��6   $
��Left=�6   $��328,117,0,0q�6:   $	��Top=�6O   $��13(�6g   5-      5.      