   M S B A M L   `   `   `  ����G  CProjekatSIMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ProjekatSIMSProjekatSIMS  5      0    *ProjekatSIMS.Sekretar.View.PageGuestNalozi   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:ProjekatSIMS     5        N� Title$  PageGuestNalozi��5	      $
��1272��6   $	��649��6,    N� 
Background
 ��ح�.��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGridGuestNalozi��5         SelectionMode$ Single=�5         AutoGenerateColumns .  $
��Left=�6F   $	��328��5      $��331,155,0,0q�6    $	��Top=�65   $	��600��6M   $��20(�6Y   ��5   0   ��  �� Path$ Guest� �� UpdateSourceTrigger$ PropertyChanged=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$	 Ime��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$		 200 6Q   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 62   �� $	 ime�6Q     5      $ Prezime��6%   $		 200 6Y   
 66   �� $ prezime�6Y     5      $
 JMBG��6%   $	 * 6S   
 63   �� $
 jMBG�6S   5      �� 5   
   -   5         ��Name$ button��5      $��Kreiraj��6!   $
��Left=�63   $��331,524,0,0q�6N   $	��Top=�6c      ButtonStyle#��[  6�   ��6{   �� *	Kreiraj+ � ToolTip 5      _� 5      .��6   " Kreiranje guest naloga pacijenta5      5      �� 5   
   -   5        $ button1��5      $��Obriši��6"   $
��Left=�63   $��562,524,0,0q�6N   $	��Top=�6c   #��[  6�   ��6{   �� *Obrisi+ 5      _� 5      .��6   &$Prvo izaberite guest nalog iz tabele5       5"      �� 5#   
   -   5        $ button2��5#      $��Nazad��6"   $
��Left=�62   $��791,524,0,0q�6M   $	��Top=�6b   #��[  6�   ��6z   �� *Nazad+6�   �� 5$   
   -   5         ��Name$ label��5$      $��Guest nalozi��6   $
��Left=�66   $��
520,50,0,0q�6Q   $	��Top=�6e     
TitleStyle#��[ 6}   5&      5'      