   M S B A M L   `   `   `  ����G  CProjekatSIMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:ProjekatSIMS.Lekar.ViewProjekatSIMS.Lekar.View  5      *    $ProjekatSIMS.Lekar.View.LekarPocetna   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:ProjekatSIMS.Lekar.View     5        N� Title$  LekarPocetna��5	      .��5      � 
�������.+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGridLekar��5         SelectionMode$ Single=�5         AutoGenerateColumns .  $
��Left=�6F   $	��235��5      $��
74,124,0,0q�6#   $	��Top=�67   $	��678��6O   $��Segoe UI Light)�6[   $��14(�6w   $��0q�6�      MinColumnWidth$	 100Q�6�      RowHeaderWidth$ 1Q�6�      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$	 112 6�   ��5   *   ��  �� Path$ ZakazTermina� �� UpdateSourceTrigger$ PropertyChanged=�	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Vrsta termina��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� $ vrstaTermina�  5      $
 Datum��6%      SortMemberPath$ PraviDatum.Date��6s    64   �� $ 
PraviDatum� �� StringFormat$ dd.MM.yyyy.��6s     5      $
 Vreme��6%    64   �� $ vreme�  5      $

 Soba��6%    63   �� $
 soba�  5      $
 Lekar��6%    64   �� $ lekar�  5      $

 Jmbg��6%      Width$ * 6S    63   �� $
 jmbg�6S   5      �� 5   
   -   5         ��Name$ button��5      $��Kreiraj��6!   $
��Left=�63   $��
74,402,0,0q�6N   $	��Top=�6b   $	��190��6z   $��30��6�   $��16(�6�   
�������
��� �����6�   �� $ Kreiraj�6�   �� 5   
   -   5        $ button2��5      $��Izmeni��6"   $
��Left=�63   $��420,402,0,0q�6N   $	��Top=�6c   $
��190 ��6{   $��30��6�   $��16(�6�   
�������
��� �����6�   �� $ Izmeni�6�   �� 5   
   -   5        $ button3��5       � ToolTip$ Izaberi pacijenta��6"   $��Karton��6>   $
��Left=�6O   $��788,124,0,0q�6j   $	��Top=�6   $	��190��6�   $��30��6�   $��16(�6�   
�������
��� �����6�   �� $ Karton�6�   �� 5   
   -   5        $ button4��5      $��Validacija leka��6"   $
��Left=�6<   $��30��6W   $��788,229,0,0q�6c   $	��Top=�6x   $��190                 ��6�   $��16(�5   7   
��� ���
���������6   �� $ 
Validacija�6Z   �� 5   
   -   5         ��Name$ logout��5      $
��Left=�6$   $��
906,10,0,0q�6?   $
��Wrap=�6S   $	��⮈��6g   $	��Top=�6w   $��48��6�   $��59��6�   $��40(�6�   6�   �� 5   
   $
��Left=�6   $��330,400,0,0q�6/   $
��Wrap=�6D   $
��🗑��6X   $	��Top=�6i   $��32��6�   $��36��6�   $��20(�6�    J� RenderTransformOrigin$ 0.444,0.458&�6�   �� 5    
   -   5         ��Name$ klikni��5       ���	#FFF4F4F5$
��Left=�65   $��44��6P   $��
840,80,0,0q�6\    �� RadiusY$ 20��6p    �� RadiusX$ 20��6}   
���   �$	��Top=�6�   $	��125��6�   $y�Hidden=�6�   �� 5!   
   -   5         ��Name$ 	klikniLab��5!      $*��$   Prvo izaberi
 pacijenta iz tabele��6#   $
��Left=�6V   $��
840,80,0,0q�6q   $	��Top=�6�   $��44��6�   $	��125��6�   $y�Hidden=�6�   �� 5"   
   -	   5        $ izaberi��5"      ���	#FFF4F4F5$
��Left=�66   $��70��6Q   $��
74,364,0,0q�6]   $ 20��6q   $ 20��6~   
���   �$	��Top=�6�   $	��159��6�   $y�Hidden=�6�   �� 5#   
   -
   5        $ 
izaberiLab��5#      $L��FAko zelite termin za 
postojeceg pacijenta,
prvo ga izaberite u tabeli��6$   $
��Left=�6}   $��
74,364,0,0q�6�   $	��Top=�6�   $��70��6�   $	��159��6�   $y�Hidden=�6�   �� 5$   
   $��Predstojeći termini��6   $
��Left=�6.   $��	74,45,0,0q�6I   $	��Top=�6\   $��52��6t   $	��274��6�   $��22(�6�   �� 5%   
   $
��Left=�6   $��788,159,0,0q�6/   $
��Wrap=�6D   $	��Top=�6t   $��65��6�   $	��177��6�   
���  ��$��16(�6�   ��6X   �� $ TMora�6�   �� 5&   
   $��Feedback aplikacije��6   $
��Left=�6/   $��788,402,0,0q�6J   $	��Top=�6_   $	��190��6w   $��30��6�   
�������
��� ���$��16(�6�   ��6�   �� $ Feedback�6�   5)      5*      