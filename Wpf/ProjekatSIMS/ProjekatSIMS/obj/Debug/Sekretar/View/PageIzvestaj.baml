   M S B A M L   `   `   `  ����G  CProjekatSIMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:ProjekatSIMS.Sekretar.ViewProjekatSIMS.Sekretar.View  5      -    'ProjekatSIMS.Sekretar.View.PageIzvestaj   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:ProjekatSIMS.Sekretar.View     5        N�Language$  en-IN�5
   6    N� Title$ PageIzvestaj��6   $	��649��6   $
��1272��6)    N� 
Background
 ��ح�.��5      � .+�5   
   �� -   5         ��Name$ label��5      $E��?Izveštaj o zauzetosti prostorija za određeni vremenski period��6   $
��Left=�6g   $��
100,62,0,0q�6�   $	��Top=�6�      
TitleStyle#��[  6�   �� 5   
   -   5        $ label1��5      $��Vremenski period��6    $
��Left=�6;   $��296,215,0,0q�6V   $	��Top=�6k     
LabelStyle#��[ 6�   �� 5   
   -   5        $ label2��5      $	��Od:��6    $
��Left=�6.   $��444,293,0,0q�6I   $	��Top=�6^   #��[ 6v   �� 5   
   -   5        $ label3��5      $	��Do:��6    $
��Left=�6.   $��445,366,0,0q�6I   $	��Top=�6^   #��[ 6v   �� 5   
   -   5         ��Name$ button��5      $��Generiši izveštaj��6!   $
��Left=�6=   $��397,516,0,0q�6X   $	��Top=�6m     ButtonStyle#��[ 6�   $	��250��6�   6�   �� 5   
   -   5        $ button1��5      $��Nazad��6"   $
��Left=�62   $��742,516,0,0q�6M   $	��Top=�6b   #��[ 6z   6�   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��myDatePicker��5   Q   $��40��6   $
��Left=�6!   $��532,295,0,0q�6<   $	��Top=�6e   $	��350��6}   $��24(�6�      SelectedDate 5      �� *myVideModelProperty+ � 	Resources 5      :  4System.Windows.Controls.Primitives.DatePickerTextBox �� 
TargetType �� Property	 �� Value
 ��Name �� Path �� RelativeSource �� AncestorType �� StringFormat��%�   '        �� 5      "  6   .�5      ��  � ��	 5      �� 5      .R�5   "   �� $
 PART_TextBox��6*   ��5   *   �� $ SelectedDate� �� "  $ {0:dd.MM.yyyy.}��5      5      5       5!      5"        5$   
   -   5        $��myDatePicker1��5%   Q   $��40��6   $
��Left=�6!   $��532,366,0,0q�6<   $	��Top=�6f   $	��350��6~   $��24(�6�    5$      �� *myVideModelProperty+ 5&      ��%�   '        �� 5'      "  6   .�5(      ��  � ��	 5)      �� 5*      .R�5+   "   �� $
 PART_TextBox��6*   ��5,   *   �� $ SelectedDate� �� "  $ {0:dd.MM.yyyy.}��5-      5/      50      51      52      53      54      