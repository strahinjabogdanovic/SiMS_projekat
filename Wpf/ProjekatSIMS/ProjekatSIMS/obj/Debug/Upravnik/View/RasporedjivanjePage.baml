   M S B A M L   `   `   `  ����G  CProjekatSIMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:ProjekatSIMS.Upravnik.ViewProjekatSIMS.Upravnik.View  5      4    .ProjekatSIMS.Upravnik.View.RasporedjivanjePage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:ProjekatSIMS.Upravnik.View     5        N� Title$  RasporedjivanjePage��5	      $��675.2��6#   $	��424��62   .��5      � .+�5   
   �� $��Premesta se u:��6   $
��Left=�6)   $��	50,50,0,0q�6E   $	��Top=�6X   $��40��6p   �� 5   
   $��Oprema za premestanje:��6   $
��Left=�61   $��
50,125,0,0q�6L   $	��Top=�6`   �� 5   
   $��Kolicina opreme:��6   $
��Left=�6+   $��
50,200,0,0q�6F   $	��Top=�6Z   �� 5   
   -   5        $��Potvrdi��5      $
��Left=�6#   $��75��6>   $��23��6I   $��265,347,0,0q�6U   $	��Top=�6j   6�   �� 5   
   -   5         ��Name$ t1��5      $
��Left=�6   $��75��69   $��23��6D   $��220,200,0,0q�6P    �� TextWrapping$
 Wrap=�6e   $	��Top=�6y   �� 5   
   -   5        $ t2��5      $
��Left=�6   $��23��69   $��220,125,0,0q�6E   $
 Wrap=�6Z   $	��Top=�6n   $	��120��6�   �� 5   
   -   5         ��Name$	 cb1��5      $
��Left=�6    $��
220,50,0,0q�6;   $	��Top=�6O   $	��120��6g   �� 5   
   -   5         ��Name$	 tb1��5      $
��Left=�6!   $��
140,33,0,0q�6<   $
��Wrap=�6P   $	��Top=�6d   �� 5   
   $��Premestiti kada:��6   $
��Left=�6+   $��
50,275,0,0q�6F   $	��Top=�6Z   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��myDatePicker��5   Q   $��25��6   $
��Left=�6!   $��220,275,0,0q�6<   $	��Top=�6e   $	��125��6}   $��15(�6�      SelectedDate 5      �� *myVideModelProperty+ � 	Resources 5      :  4System.Windows.Controls.Primitives.DatePickerTextBox �� 
TargetType �� Property	 �� Value
 �� Path �� RelativeSource �� AncestorType �� StringFormat��%�   '        �� 5      "  6   .�5      ��  � ��	 5      �� 5      .R�5   "   �� $ PART_TextBox��6*   ��5   *   �� $
 SelectedDate� �� "  $ {0:dd.MM.yyyy.}��5      5       5!      5"      5#      �� 5$   
   -   5        $��Nazad��5$      $
��Left=�6!   $��
91,347,0,0q�6<   $	��Top=�6P   $��75��6h   $��23��6s   6   5%      5&      