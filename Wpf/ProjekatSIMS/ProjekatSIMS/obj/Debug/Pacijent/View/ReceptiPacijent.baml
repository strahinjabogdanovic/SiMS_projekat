   M S B A M L   `   `   `  ����G  CProjekatSIMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ProjekatSIMSProjekatSIMS  5   	   "    ProjekatSIMS.ReceptiPacijent   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:ProjekatSIMS     5   	     � WindowStartupLocation$  CenterScreen=�5   0    � Title$ ReceptiPacijent��5   	   $	��450��6!   $	��800��6.   
����ح�.��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGridLekar��5
         SelectionMode$ Single=�5         AutoGenerateColumns .  $
��Left=�6F   $	��288��5      $��
109,37,0,0q�6    $	��Top=�64   $	��577��6L      
IsReadOnly . ��5
   *   ��  �� Path$ ReceptiSpisak� �� UpdateSourceTrigger$ PropertyChanged=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 
Sifra Leka��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 * 6^   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� $ 	sifraLeka�6^     5      $	 
Naziv Leka��6%   $
 * 6^    69   �� $ 	nazivLeka�6^     5      $	 Način uzimanja��6%   $
 * 6f    6=   �� $ nacinUzimanja�6f     5      $!	 Na koliko sati se lek uzima��6%   $
 * 6r    6J   �� $ naKolikoSati�6r   5      �� 5   
   -   5        $��	Podsetnik��5      $
��Left=�6%   $��324,360,0,0q�6@   $	��Top=�6U   $	��138��6m   $��20(�6�   5      5      