   M S B A M L   `   `   `  ����G  CProjekatSIMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:ProjekatSIMS.Sekretar.ViewProjekatSIMS.Sekretar.View  5      1    +ProjekatSIMS.Sekretar.View.PagePrikazLekara   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:ProjekatSIMS.Sekretar.View     5        N� Title$  PagePrikazLekara��5	      $	��649��6    $
��1272��6-    N� 
Background
 ��ح�.��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGridPrikazLekara��5         SelectionMode$ Single=�5         AutoGenerateColumns .  $
��Left=�6F   $	��383��5      $��
31,173,0,0q�6    $	��Top=�64   $
��1211��6L   $��20(�6Y   ��5   1   ��  �� Path$ Lekari� �� UpdateSourceTrigger$ PropertyChanged=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$	 Ime��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$		 160 6Q   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 62   �� $	 ime�6Q     5      $ Prezime��6%   $		 160 6Y   
 66   �� $ prezime�6Y     5      $ Specijalizacija��6%   $		 160 6f   
 6>   �� $ specijalnost�6f     5      $
 JMBG��6%   $		 160 6S   
 63   �� $
 jmbg�6S     5      $ Datum rođenja��6%   $		 160 6e   
 6<   �� $ datumRodjenja�6e     5      $ Email��6%   $		 250 6U   
 64   �� $ email�   ElementStyle 5      �� 5      .�5      ��  �� Property � �� �� Value$
 Wrap=�6C   �� 5       �@��TextAlignment$ Center=�6D   5      5        5      $ Broj telefona��6%   $	 * 6d   
 6<   �� $ brojTelefona�6d   5      �� 5    
   -   5         ��Name$ label��5       $��Lekari��6   $
��Left=�60   $��	31,84,0,0q�6K   $	��Top=�6^      
TitleStyle#��[  6v   �� 5!   
   -   5         ��Name$ button��5!      $��Nazad��6!   $
��Left=�61   $��538,575,0,0q�6L   $	��Top=�6a     ButtonStyle#��[ 6�   ��6y   �� *Nazad+6�   �� 5"   
   -   5        $ button1��5"      $ ��Grafikon zauzetosti lekara��6"   $
��Left=�6G   $��907,100,0,0q�6b   $	��Top=�6w   $	��335��6�   #��[ 6�   ��6�   �� *
Grafikon+6�   5#      5$      