   M S B A M L   `   `   `  ����G  CProjekatSIMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ProjekatSIMSProjekatSIMS  5   	        ProjekatSIMS.IzmenaProfila   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:ProjekatSIMS     5   	     � Title$  IzmenaProfila��5   	    � SizeToContent$ WidthAndHeight=�6   
����ح� � WindowStartupLocation$ CenterScreen=�6U   .��5	      � $	��350��6   $	��450��6    � RowDefinitions 5
   
   �� 5      $��45 �6   �� 5      $��20 �6   �� 5      $��70 �6   �� 5      $��70 �6   �� 5      $��70 �6   �� 5      $��15 �6   �� 5      $��45 �6   �� 5      $��15 �6    � ColumnDefinitions 5   
   �� 5      $	��190 �6   �� 5      $	��260 �6   .+�5   
   �� $��0��6   $��0��6   $��Izmena profila��6-   $��23(�6F   $��Italic$�6T   �� 5   
   $��2��6   $��0��6   $��Adresa��6-   $��20(�6>   �� 5   
   $��3��6   $��0��6   $��E-mail��6-   $��20(�6>   �� 5   
   $��4��6   $��0��6   $��Broj telefona��6-   $��20(�6E   �� 5   
   $��1��6   $��2��6%   .+�5      �� $��1��6   $��2��6&   $	��250��63   $��42��6?   $��20(�6K   ��6Y   ��  �� Path$ Adresa��� 5      
���  ��$��16(�6S   $��Center=�6a   ��6   �� *ValidationErrors[Adresa]+6a   5      �� 5    
   $��1��6   $��3��6%   .+�5!      �� $��1��6   $��3��6&   $	��250��63   $��42��6?   $��20(�6K   ��6Y   �� $ Email��� 5"      
���  ��$��16(�6R   $��Center=�6`   ��6   �� *ValidationErrors[Email]+6`   5#      �� 5$   
   $��1��6   $��4��6%   .+�5%      �� $��1��6   $��4��6&   $	��250��63   $��42��6?   $��20(�6K   ��6Y   �� $ Telefon��� 5&      
���  ��$��16(�6T   $��Center=�6b   ��6   �� *ValidationErrors[Telefon]+6b   5'      �� 5(   
   $��6��6   $��0��6"   $��2��62    �� Orientation$ 
Horizontal=�6F   .+�5)      �� $��Odustani��6   $	��110��6(   $��42��64   $��90, 0, 0 , 0q�6@   ��6V   �� *OdustaniOdIzmena+�� 5*      $��Potvrdi��6   $	��110��6'   $��42��63   $��40, 0, 0 , 0q�6?   ��6U   �� *PotvrdiIzmene+5+      5-      5.      