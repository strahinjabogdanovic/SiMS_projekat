   M S B A M L   `   `   `  ����G  CProjekatSIMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ProjekatSIMSProjekatSIMS  5      -    'ProjekatSIMS.Sekretar.View.PageSekretar   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:ProjekatSIMS     5        N� Title$  PageSekretar��5	      $	��649��6   $
��1272��6)    N� 
Background
 ��ح�.��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGridNalozi��5         SelectionMode$ Single=�5         AutoGenerateColumns .  $
��Left=�6F   $	��329��5      $��
55,173,0,0q�6    $	��Top=�64   $	��793��6L   $��20(�6X   ��5   +   ��  �� Path$ 	Korisnici� �� UpdateSourceTrigger$ PropertyChanged=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$	 Ime��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$		 160 6Q   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 62   �� $	 ime�6Q     5      $ Prezime��6%   $		 160 6Y   
 66   �� $ prezime�6Y     5      $
 JMBG��6%   $		 160 6S   
 63   �� $
 jMBG�6S     5      $ Datum rođenja��6%   $		 160 6e   
 6<   �� $ datumRodjenja�6e     5      $ Broj telefona��6%   $	 * 6d   
 6<   �� $ brojTelefona�6d   5      �� 5   
   -   5         ��Name$ button��5      $��Kreiraj��6!   $
��Left=�63   $��
55,555,0,0q�6N   $	��Top=�6b      ButtonStyle#��[  6�   ��6z   �� *	Kreiraj+ � ToolTip 5      _� 5      .��6   Kreiranje naloga pacijenta5      5      �� 5   
   -   5        $ button1��5      $��Obriši��6"   $
��Left=�63   $��241,555,0,0q�6N   $	��Top=�6c   #��[  6�   ��6{   �� *Obrisi+ 5      _� 5       .��6    Prvo izaberite nalog iz tabele5"      5$      �� 5%   
   -   5        $ button2��5%      $��Izmeni��6"   $
��Left=�63   $��419,555,0,0q�6N   $	��Top=�6c   #��[  6�   ��6{   �� *Izmeni+ 5&      _� 5'      .��6    Prvo izmenite podatak u tabeli5)      5+      �� 5-   
   -   5        $ button4��5-      $��Guest nalozi��6"   $��938,230,0,0q�69   $	��250��6N   #��[  6y   $��44��6�   $
��Left=�6�   $	��Top=�6�   $��Center=�6�   $��Center=�6  ���	#FFDDDDDD��6Z   �� *
GuestNalog+6/  �� 5.   
   -   5         ��Name$ label��5.      $��Nalozi pacijenata��6   $
��Left=�6;   $��	55,80,0,0q�6V   $	��Top=�6i     
TitleStyle#��[ 6�   �� 5/   
   -   5        $ button5��5/      $��Obaveštenja��6"   $��938,295,0,0q�68   $	��250��6M   #��[  6y   $
��Left=�6�   $	��Top=�6�   $��Center=�6�   $��Center=�6  ���	#FFDDDDDD��6Y   �� *Obavestenja+6#  �� 50   
   -   5        $ button6��50      $��Medicinski karton��6"   $
��Left=�6>   $��598,555,0,0q�6Y   $	��Top=�6n   $	��250��6�   #��[  6�   ��6�   �� *	MedKarton+ 51      _� 52      .��6    Prvo izaberite nalog iz tabele54      56      �� 57   
   -	   5        $ button7��57      $��Termini��6"   $��938,165,0,0q�64   $	��250��6I   #��[  6q   $
��Left=�6�   $	��Top=�6�   $��Center=�6�   $��Center=�6�   ���	#FFDDDDDD��6U   �� *	Termini+6  �� 58   
   -
   5        $ button8��58      $��Hitno zakazivanje��6"   $��938,100,0,0q�6>   $	��250��6S   #��[  6�   $
��Left=�6�   $	��Top=�6�   $��Center=�6�   $��Center=�6  ���	#FFDDDDDD��6_   �� *HitnoZakazivanje+6.  �� 59   
   -   5        $ button3��59      $��
Prostorije��6"   $��938,425,0,0q�67   $	��250��6L   #��[  6w   $
��Left=�6�   $	��Top=�6�   $��Center=�6�   $��Center=�6�   ���	#FFDDDDDD��6X   �� *
Prostorije+6!  �� 5:   
   -   5        $ button9��5:      $��Lekari��6"   $��938,360,0,0q�63   $	��250��6H   #��[  6o   $��46��6�   $
��Left=�6�   $	��Top=�6�   $��Center=�6�   $��Center=�6  ���	#FFDDDDDD��6T   �� *Lekari+6%  �� 5;   
   -   5        $ button10��5;      $��	Anti-trol��6#   $��938,490,0,0q�67   $	��250��6L   #��[  6u   $
��Left=�6�   $	��Top=�6�   $��Center=�6�   $��Center=�6�   ���	#FFDDDDDD��6X   �� *
Antitrol+6  �� 5<   
   -   5        $ button11��5<      $��	Izveštaj��6#   $��938,555,0,0q�66   $	��250��6K   #��[  6t   $
��Left=�6�   $	��Top=�6�   $��Center=�6�   $��Center=�6�   ���	#FFDDDDDD��6W   �� *
Izvestaj+6  �� 5=   
   -   5        $ button12��5=      $��Feedback��6#   $
��Left=�66   $��
938,36,0,0q�6Q   $	��Top=�6e   $	��250��6}   #��[  6�   ��6�   �� *
Feedback+6�   5>      5?      