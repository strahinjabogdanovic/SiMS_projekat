   M S B A M L   `   `   `  ����G  CProjekatSIMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:ProjekatSIMS.Upravnik.ViewProjekatSIMS.Upravnik.View  5      -    'ProjekatSIMS.Upravnik.View.UpravnikPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:ProjekatSIMS.Upravnik.View     5        N� Title$  UpravnikPage��5	      $��675.2��6   $	��424��6+   .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGridProstorije��5         SelectionMode$ Single=�5         AutoGenerateColumns .  $
��Left=�6F   $	��489��5      $��8,47,0,0q�6    $	��Top=�62   $	��402��6J   ��5   /   ��  �� Path$ 
Prostorije�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$	 Ime��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 62   �� $	 ime�  5      $ Oznaka��6%    65   �� $ oznaka�  5      $ Namena��6%    65   �� $ namena�  5      $ Oprema��6%    65   �� $ oprema�   ElementStyle 5      �� 5      .�5      �� 	 �� Property	 � ��
 �� Value$

 Wrap=�6C   �� 5      	 �@��TextAlignment$
 Center=�6D   5      5        5      $ Renoviranje��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 70 6a    6:   �� $ renoviranje�6a   5      �� 5   
   -   5         ��Name$ button��5      $��Dodaj��6!   $
��Left=�61   $��
15,550,0,0q�6L   $	��Top=�6`   $��90��6x   $��20��6�   ��6�   �� *	Kreiraj+�� 5   
   -   5        $ button1��5      $��Obrisi��6"   $
��Left=�63   $��115,550,0,0q�6N   $	��Top=�6c   $��90��6{   $��20��6�   ��6�   �� *Obrisi+�� 5    
   -   5        $ button4��5       $��Oprema��6"   $
��Left=�63   $��320,550,0,0q�6N   $	��Top=�6c   $��90��6{   $��20��6�   ��6�   �� *Oprema+�� 5!   
   -   5         ��Name$	 tb1��5!   ,   $
��Left=�69   $��23��6T   $��
243,24,0,0q�6`    �� TextWrapping$
 Wrap=�6t   $	��Top=�6�   $	��120��6�   ��6   �� *
Pretraga+6�   �� 5"   
   $��pretrazi��6   $
��Left=�6$   $��
363,24,0,0q�6?   $	��Top=�6S   $��47��6k   $��23��6v   ��6�   �� *
Pretrazi+�� 5#   
   $��Renoviranje��6   $
��Left=�6'   $��215,550,0,0q�6B   $	��Top=�6W   $��90��6o   $��20��6z   ��6�   �� *Renoviranje+�� 5$   
   $��
Prostorije��6   $
��Left=�6%   $��5,22,0,0q�6@   $	��Top=�6R   $��24��6j   �� 5%   
   $��	Izveštaj��6   $
��Left=�6$   $	��Top=�6?   $��75��6W   $��	243,0,0,0q�6b   ��6u   �� *
Izvestaj+�� 5&   
   $��Feedback��6   $
��Left=�6$   $��	335,0,0,0q�6?   $	��Top=�6R   $��75��6j   ��6u   �� *
Feedback+5'      5(      