   M S B A M L   `   `   `  ����G  CProjekatSIMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ProjekatSIMSProjekatSIMS  5      8    2ProjekatSIMS.Sekretar.View.PageObavestenjaSekretar   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:ProjekatSIMS     5        N� Title$  PageObavestenjaSekretar��5	      $
��1272��6'   $	��649��64    N� 
Background
 ��ح�.��5      � .+�5   
   �� -   5         ��Name$ label��5      $��Obaveštenja��6   $
��Left=�65   $��
504,44,0,0q�6P   $	��Top=�6d      
TitleStyle#��[  6|   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGridObavestenja��5         SelectionMode$ Single=�5         AutoGenerateColumns .  $
��Left=�6F   $	��329��5      $��
55,173,0,0q�6    $	��Top=�64   $
��1155��6L   $��20(�6Y   ��5   0   ��  �� Path$ Obavesti� �� UpdateSourceTrigger$ PropertyChanged=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Obaveštenje vide��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 170 6`   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   �� $ uloga�   ElementStyle 5      �� 5      .�5      ��  �� Property � �� �� Value$
 Wrap=�6G   �� 5       �@��TextAlignment$ Center=�6H   5      5        5      $	 Naziv��6%   $	
 250 6U    64   �� $ naziv� 5      �� 5      .�5      ��  � ��$
 Wrap=�6G   �� 5       �@��TextAlignment$ Center=�6H   5       5"        5#      $	 Sadržaj��6%   $
 * 6Y    66   �� $ sadrzaj� 5$      �� 5%      .�5&      ��  � ��$
 Wrap=�6G   �� 5'       �@��TextAlignment$ Center=�6H   5(      5*        5+      $	 Datum��6%   $	
 160 6U    64   �� $ datum�6U   5-      �� 5.   
   -   5         ��Name$ button��5.      $��Kreiraj��6!   $
��Left=�63   $��238,549,0,0q�6N   $	��Top=�6c     ButtonStyle#��[ 6�   ��6{   �� *	Kreiraj+ � ToolTip 5/      _� 50      .��6   Kreiranje obaveštenja52      54      �� 55   
   -   5        $ button1��55      $��Obriši��6"   $
��Left=�63   $��454,549,0,0q�6N   $	��Top=�6c   #��[ 6�   ��6{   �� *Obrisi+ 56      _� 57      .��6   '%Prvo izaberite obaveštenje iz tabele59      5;      �� 5<   
   -   5        $ button2��5<      $��Izmeni��6"   $
��Left=�63   $��660,549,0,0q�6N   $	��Top=�6c   #��[ 6�   ��6{   �� *Izmeni+ 5=      _� 5>      .��6    Prvo izmenite podatak u tabeli5@      5B      �� 5C   
   -   5        $ button3��5C      $��Nazad��6"   $
��Left=�62   $��870,549,0,0q�6M   $	��Top=�6b   #��[ 6�   ��6z   �� *Nazad+6�   5E      5F      