   M S B A M L   `   `   `  ����G  CProjekatSIMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ProjekatSIMSProjekatSIMS  5      4    .ProjekatSIMS.Sekretar.View.PageTerminiSekretar   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:ProjekatSIMS     5        N� Title$  PageTerminiSekretar��5	      $
��1272��6#   $	��649��60    N� 
Background
 ��ح�.��5      � .+�5   
   �� -   5         ��Name$ label��5      $��Termini��6   $
��Left=�61   $��	55,84,0,0q�6L   $	��Top=�6_      
TitleStyle#��[  6w   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGridTerminiSekretar��5         SelectionMode$ Single=�5         AutoGenerateColumns .  $
��Left=�6F   $	��329��5      $��
55,186,0,0q�6    $	��Top=�64   $	��771��6L   $��20(�6X   ��5   4   ��  �� Path$ TerminiP� �� UpdateSourceTrigger$ PropertyChanged=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Pacijent��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 160 6\   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� $ 	pacijenti�6\     5      $	 Datum��6%   $	
 160 6U    64   �� $ datum�6U     5      $	 Vreme��6%   $	
 160 6U    64   �� $ vreme�6U     5      $	 Lekar��6%   $	
 160 6U    64   �� $ lekar�6U     5      $
	 Soba��6%   $
 * 6S    63   �� $
 soba�6S   5      �� 5   
   -   5         ��Name$ button��5      $��Zakazivanje termina��6!   $
��Left=�6?   $��936,186,0,0q�6Z   $	��Top=�6o   $	��250��6�     ButtonStyle#��[ 6�   ��6�   �� *Zakazivanje+6�   �� 5   
   -   5        $ button1��5      $��Otkazivanje termina��6"   $
��Left=�6@   $��936,300,0,0q�6[   $	��Top=�6p   $	��250��6�   #��[ 6�   ��6�   �� *Otkazivanje+ � ToolTip 5      _� 5      .��6   !Prvo izaberite termin iz tabele5      5!      �� 5"   
   -   5        $ button2��5"      $��Promena termina��6"   $
��Left=�6<   $��936,420,0,0q�6W   $	��Top=�6l   $	��250��6�   #��[ 6�   ��6�   �� *	Promena+ 5#      _� 5$      .��6    Prvo izmenite podatak u tabeli5&      5(      �� 5)   
   -   5        $ button3��5)      $��Nazad��6"   $
��Left=�62   $��554,557,0,0q�6M   $	��Top=�6b   #��[ 6�   ��6z   �� *Nazad+6�   5*      5+      