   M S B A M L   `   `   `  ����G  CProjekatSIMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ProjekatSIMSProjekatSIMS  5      7    1ProjekatSIMS.Sekretar.View.PageKreirajObavestenje   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:ProjekatSIMS     5        N�Language$  en-IN�5
   @    N� Title$ PageKreirajObavestenje��6   $
��1272��6&   $	��649��63    N� 
Background
 ��ح�.��5      � .+�5   
   �� -   5         ��Name$ label��5      $��Kreiranje obaveštenja��6   $
��Left=�6?   $��
422,48,0,0q�6Z   $	��Top=�6n      
TitleStyle#��[  6�   �� 5   
   -   5        $ label1��5      $��Naziv obaveštenja��6    $
��Left=�6<   $��108,307,0,0q�6W   $	��Top=�6l     
LabelStyle#��[ 6�   �� 5   
   -   5        $ label2��5      $��Sadržaj obaveštenja��6    $
��Left=�6>   $��
90,427,0,0q�6Y   $	��Top=�6m   #��[ 6�   �� 5   
   -   5         ��Name$ button��5      $��Nazad��6!   $
��Left=�61   $��670,582,0,0q�6L   $	��Top=�6a     ButtonStyle#��[ 6�   ��6y   �� *
Odustani+6�   �� 5   
   -   5        $ button1��5      $��Potvrdi��6"   $
��Left=�64   $��446,582,0,0q�6O   $	��Top=�6d   #��[ 6�   ��6|   �� *	Potvrdi+6�   �� 5   
   -   5         ��Name$ textBox��5   &   $
��Left=�67   $��77��6R   $��334,311,0,0q�6^    �� TextWrapping$
 Wrap=�6s   $	��Top=�6�   $	��774��6�   $��24(�6�   ��6   �� *S1+6�   �� 5   
   -   5        $ textBox1��5   &   $
��Left=�68   $	��127��6S   $��334,431,0,0q�6`   $
 Wrap=�6u   $	��Top=�6�   $	��774��6�   $��24(�6�   ��6   �� *S2+6�   �� 5   
   -   5        $ textBox3��5   &   $
��Left=�68   $��334,223,0,0q�6S   $
 Wrap=�6h   $	��Top=�6|     TextBoxStyle#��[ 6�   $	��350��6�   ��6   �� *S3+6�   �� 5   
   -	   5        $ label3��5      $��Datum��6    $
��Left=�60   $��229,138,0,0q�6K   $	��Top=�6`   #��[ 6x   �� 5   
   -
   5        $ label4��5      $��Obaveštenja vide��6    $
��Left=�6;   $��118,219,0,0q�6V   $	��Top=�6k   #��[ 6�   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��myDatePicker��5   Q   $��40��6   $
��Left=�6!   $��334,140,0,0q�6<   $	��Top=�6e   $	��350��6}   $��24(�6�      SelectedDate 5      ��  �� Path$
 Date�	 �� Mode$	 TwoWay=�
 � 	Resources
 5      :  4System.Windows.Controls.Primitives.DatePickerTextBox �� 
TargetType �� Property �� Value �� RelativeSource �� AncestorType �� StringFormat��%�   '        �� 5      "  6   .�5      ��  � �� 5      �� 5      .R�5   "   �� $ PART_TextBox��6*   ��5   %   �� $ SelectedDate� �� "  $ {0:dd.MM.yyyy.}��5       5"      5#      5$      5%      �� 5&   
   -   5         ��Name$ 	textBlock��5&      $
��Left=�6'   $��334,185,0,0q�6B   $
��Wrap=�6W   $	��Top=�6k   
���  ��$��24(�6�   $	��411��6�   $��38��6�   ��6�   �� *ValidationErrors[vidljivost]+6�   �� 5'   
   -   5        $ 
textBlock1��5'      $
��Left=�6(   $��334,273,0,0q�6C   $
��Wrap=�6X   $	��Top=�6l   
���  ��$��24(�6�   $	��411��6�   $��38��6�   ��6�   �� *ValidationErrors[naziv]+6�   �� 5(   
   -   5        $ 
textBlock2��5(      $
��Left=�6(   $��334,393,0,0q�6C   $
��Wrap=�6X   $	��Top=�6l   
���  ��$��24(�6�   $	��411��6�   $��38��6�   ��6�   �� *ValidationErrors[sadrzaj]+6�   5*      5+      