   M S B A M L   `   `   `  ����G  CProjekatSIMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:ProjekatSIMS.Lekar.ViewProjekatSIMS.Lekar.View  5      $    ProjekatSIMS.Lekar.View.Lekovi   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:ProjekatSIMS.Lekar.View     5        N� Title$  Lekovi��5	      .��5      � 
�������.+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGridLekovi��5         SelectionMode$ Single=�5         AutoGenerateColumns .  $
��Left=�6F   $	��240��5      $��128,120,0,0q�6#   $	��Top=�68   $	��757��6P   $��16(�6\   ��5   +   ��  �� Path$ 	SviLekovi� �� UpdateSourceTrigger$ PropertyChanged=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Šifra leka��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� $ 	sifraleka�  5      $ 
Naziv Leka��6%    69   �� $ 	nazivleka�  5      $ Sastojci��6%    67   �� $ sastojci�  5      $ Zamena��6%    65   �� $ zamena�  5      $ 	Validiran��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 * 6]    68   �� $ 	validiran�6]   5      �� 5   
   $��Izmeni��6   $
��Left=�6"   $��128,418,0,0q�6=   $	��Top=�6R   $	��190��6j   $��30��6v   
�������
��� ���$��16(�6�   ��6�   �� $ Izmeni�6�   �� 5   
   $��Postoji greška-upravniku��6   $
��Left=�64   $��695,418,0,0q�6O   $	��Top=�6d   $	��190��6|   $��30��6�   $��16(�6�   
�������
��� �����6�   �� *	Upravniku+6�   �� 5   
   $
��🠔��6   $
��Left=�6   $��	33,33,0,0q�69   $	��Top=�6M   $��40��6e   $��64��6q   $��30(�6|   
 J� RenderTransformOrigin$
 0.516,0.533&�6�   
�������
�������
����  ���6�   �� *Nazad+6�   �� 5   
   $��Lekovi��6   $
��Left=�6!   $��
128,64,0,0q�6<   $	��Top=�6P   $��22(�6h   5      5      