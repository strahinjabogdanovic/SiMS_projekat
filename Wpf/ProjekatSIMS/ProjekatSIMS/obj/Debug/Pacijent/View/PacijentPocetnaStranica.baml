   M S B A M L   `   `   `  ����c  _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5   	   G CProjekatSIMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ProjekatSIMSProjekatSIMS 5   	   *   $ProjekatSIMS.PacijentPocetnaStranica   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   	   ,localclr-namespace:ProjekatSIMS     5   	     � Title$  PacijentPocetnaStranica��5	   	   $	��500��6)   $	��700��66   
����ح� � WindowStartupLocation$ CenterScreen=�6Y   .��5
      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGridPacijenti��5   E      SelectionMode$ Single=�5         AutoGenerateColumns .  $
��Left=�6F      
IsReadOnly . $	��274��5      $��	64,61,0,0q�6    $	��Top=�63   $	��563��6K    �� SelectedItem 5      ��  �� Path$ SelectedAppointment���6`   �� $ TerminiP� �� UpdateSourceTrigger$ PropertyChanged=�	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Datum��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6U   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� $ datum�6U     5      $
 Vreme��6%   $ * 6U    64   �� $ vreme�6U     5      $
 Lekar��6%   $ * 6U    64   �� $ lekar�6U     5      $

 Soba��6%   $ * 6S    63   �� $
 soba�6S   5      �� 5   
   -   5         ��Name$ button��5      $��Zakazivanje��6!   $
��Left=�67   $��
30,380,0,0q�6R   $	��Top=�6f   $	��130��6~   $��42��6�   $��20(�6�   ��6�   �� *Zakazivanje+�� 5   
   -   5        $ button1��5      $��Otkazivanje��6"   $
��Left=�68   $��197,380,0,0q�6S   $	��Top=�6h   $	��130��6�   $��42��6�   $��20(�6�   ��6�   �� *Otkazivanje+�� 5   
   -   5        $ button2��5      $��	Pomeranje��6"   $
��Left=�66   $��360,380,0,0q�6Q   $	��Top=�6f   $	��130��6~   $��42��6�   $��20(�6�   ��6�   �� *	Pomeranje+�� 5   
   $��Izvestaj��6   $
��Left=�6$   $��524,380,0,0q�6?   $	��Top=�6T   $	��130��6l   $��42��6x   $��20(�6�    J� RenderTransformOrigin$ 
0.377,0.61&�6�   ��6�   �� *
Izvestaj+5      5      