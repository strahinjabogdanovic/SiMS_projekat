   M S B A M L   `   `   `  ����G  CProjekatSIMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:ProjekatSIMS.Upravnik.ViewProjekatSIMS.Upravnik.View  5      -    'ProjekatSIMS.Upravnik.View.IzvestajPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:ProjekatSIMS.Upravnik.View     5        N� Title$  IzvestajPage��5	      $��675.2��6   $	��424��6+   .��5      � .+�5   
   �� -   5         ��Name$ label��5      $��30(�6   $%��  Izveštaj o zauzetosti lekara��6.   $��Center=�6W   $��	10,57,0,0q�6t   $	��Top=�6�      
TitleStyle#��[  6�   $��70��6�   $	��404��6�   �� 5   
   -   5        $ label1��5      $��Vremenski period��6    $
��Left=�6;   $��
20,190,0,0q�6V   $	��Top=�6j     
LabelStyle#��[ 6�   �� 5   
   -   5        $ label2��5      $	��Od:��6    $
��Left=�6.   $��
20,293,0,0q�6I   $	��Top=�6]   #��[ 6u   �� 5   
   -   5        $ label3��5      $	��Do:��6    $
��Left=�6.   $��
20,366,0,0q�6I   $	��Top=�6]   #��[ 6u   �� 5   
   -   5         ��Name$ button��5      $��Generiši izveštaj��6!   $
��Left=�6=   $��
60,540,0,0q�6X   $	��Top=�6l     ButtonStyle#��[ 6�   $	��304��6�   6�   �� 5   
   -   5        $ button1��5      $��Nazad��6"   $
��Left=�62   $��139,600,0,0q�6M   $	��Top=�6b   #��[ 6z   6�   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��myDatePicker��5   P   $��40��6   $
��Left=�6!   $��
80,295,0,0q�6<   $	��Top=�6d   $	��300��6|   $��24(�6�      SelectedDate 5      �� *myVideModelProperty+ � 	Resources 5      :  4System.Windows.Controls.Primitives.DatePickerTextBox �� 
TargetType �� Property �� Value ��Name	 �� Path
 �� RelativeSource �� AncestorType �� StringFormat��%�   '        �� 5      "  6   .�5      ��  � �� 5      �� 5      .R�5   "   �� $ PART_TextBox��6*   ��5   *   �� $	 SelectedDate�
 �� "  $ {0:dd.MM.yyyy.}��5      5      5      5       5!        5#   
   -   5        $��myDatePicker1��5$   P   $��40��6   $
��Left=�6!   $��
80,366,0,0q�6<   $	��Top=�6e   $	��300��6}   $��24(�6�    5#      �� *myVideModelProperty+ 5%      ��%�   '        �� 5&      "  6   .�5'      ��  � �� 5(      �� 5)      .R�5*   "   �� $ PART_TextBox��6*   ��5+   *   �� $	 SelectedDate�
 �� "  $ {0:dd.MM.yyyy.}��5,      5.      5/      50      51      52      53      