   M S B A M L   `   `   `  ����G  CProjekatSIMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ProjekatSIMSProjekatSIMS  5   	       ProjekatSIMS.IzvestajView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:ProjekatSIMS     5   	     � Title$  IzvestajView��5   	   $	��350��6   $	��500��6+   
����ح� � WindowStartupLocation$ CenterScreen=�6N   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��179* �6   �� 5      $	��67* �6   .+�5   
   (  "System.Windows.Controls.DatePicker  $
��Left=�6   $��173,104,0,0q�60   $	��Top=�6E   $��20(�6�      SelectedDate 6]   ��  �� Path$ PocetniDatum�6�     5   
   $
��Left=�6   $��173,163,0,0q�60   $	��Top=�6E   $��20(�6�    6]   �� $ KrajnjiDatum�6�   �� 5   
   $��Generisi izvestaj��6   $
��Left=�6-   $��147,249,0,0q�6H   $	��Top=�6]   $	��201��6u   $��36��6�   $��20(�6�   ��6�   �� *prikaziIzvestaj+6�   �� 5   
   $.��(Izaberite period za koji zelite izvestaj��6   $
��Left=�6C   $��	85,43,0,0q�6^   $	��Top=�6q   $��20(�6�   $��2��6�   $	��334��6�   5      5      