   M S B A M L   `   `   `  ����G  CProjekatSIMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ProjekatSIMSProjekatSIMS  5      *    $ProjekatSIMS.Sekretar.View.PageDatum   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:ProjekatSIMS     5        N�Language$  en-IN�5
   3    N� Title$ 	PageDatum��6   $
��1272��6   $	��649��6&    N� 
Background
 ��ح�.��5      � .+�5   
   �� -   5         ��Name$ label��5      $!��Izaberite datum zakazivanja��6   $
��Left=�6E   $��
393,89,0,0q�6`   $	��Top=�6t      
TitleStyle#��[  6�   �� 5   
   -   5         ��Name$ button��5      $��Nazad��6!   $
��Left=�61   $��685,466,0,0q�6L   $	��Top=�6a     ButtonStyle#��[ 6�   �� 5   
   -   5        $ label1��5      $��Datum��6    $
��Left=�60   $��418,278,0,0q�6K   $	��Top=�6`     
LabelStyle#��[ 6x   �� 5   
   -   5        $ button1��5      $��Potvrdi��6"   $
��Left=�64   $��463,466,0,0q�6O   $	��Top=�6d   #��[ 6�   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��myDatePicker��5   Q   $��40��6   $
��Left=�6!   $��521,280,0,0q�6<   $	��Top=�6e   $	��350��6}   $��24(�6�      SelectedDate 5      �� *myVideModelProperty+ � 	Resources 5      :  4System.Windows.Controls.Primitives.DatePickerTextBox �� 
TargetType �� Property	 �� Value
 ��Name �� Path �� RelativeSource �� AncestorType �� StringFormat��%�   '        �� 5      "  6   .�5      ��  � ��	 5      �� 5      .R�5   "   �� $
 PART_TextBox��6*   ��5   %   �� $ SelectedDate� �� "  $ {0:dd.MM.yyyy.}��5      5      5      5      5      5!      5"      