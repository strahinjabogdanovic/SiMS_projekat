   M S B A M L   `   `   `  ����G  CProjekatSIMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ProjekatSIMSProjekatSIMS  5      5    /ProjekatSIMS.Sekretar.View.PageZakazivanjeDatum   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:ProjekatSIMS     5        N� Title$  PageZakazivanjeDatum��5	      $
��1272��6$   $	��649��61    N� 
Background
 ��ح�.��5      � .+�5   
   �� -   5         ��Name$ label��5      $��Termini��6   $
��Left=�61   $��
563,66,0,0q�6L   $	��Top=�6`      
TitleStyle#��[  6x   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGridTerminiDatum��5         SelectionMode$ Single=�5         AutoGenerateColumns .  $
��Left=�6F   $	��329��5      $��269,190,0,0q�6    $	��Top=�65   $	��719��6M   $��20(�6Y   ��5   1   ��  �� Path$ TerminiP� �� UpdateSourceTrigger$ PropertyChanged=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Pacijent��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 160 6\   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� $ 	pacijenti�6\     5      $	 Datum��6%   $	
 160 6U    64   �� $ datum�6U     5      $	 Vreme��6%   $	
 160 6U    64   �� $ vreme�6U     5      $	 Lekar��6%   $	
 160 6U    64   �� $ lekar�6U     5      $
	 Soba��6%   $
 * 6S    63   �� $
 soba�6S   5      �� 5   
   -   5         ��Name$ button��5      $��Nazad��6!   $
��Left=�61   $��811,565,0,0q�6L   $	��Top=�6a     ButtonStyle#��[ 6�   ��6y   �� *Nazad+6�   �� 5   
   -   5        $ button1��5      $��Zakaži��6"   $
��Left=�63   $��313,565,0,0q�6N   $	��Top=�6c   #��[ 6�   ��6{   �� *Zakazi+ � ToolTip 5      _� 5      .��6   /-Prvo unesite ime i prezime pacijenta u tabelu5      5       �� 5!   
   -   5        $ button2��5!      $��Nazad na sve termine��6"   $
��Left=�6A   $��498,565,0,0q�6\   $	��Top=�6q   $	��265��6�   $��24(�6�   $��45��6�   ��6�   �� *NazadTermini+5"      5#      