   M S B A M L   `   `   `  ����G  CProjekatSIMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:ProjekatSIMS.Upravnik.ViewProjekatSIMS.Upravnik.View  5      +    %ProjekatSIMS.Upravnik.View.OpremaPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:ProjekatSIMS.Upravnik.View     5        N� Title$  
OpremaPage��5	      $��675.2��6   $	��424��6)   .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGridOprema��5         SelectionMode$ Single=�5         AutoGenerateColumns .  $
��Left=�6F   $	��300��5      $��	10,47,0,0q�6    $	��Top=�63   $	��400��6K   ��5   +   ��  �� Path$ Oprema�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Naziv��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� $ opreme�   ElementStyle 5      �� 5      .�5      �� 	 �� Property	 � ��
 �� Value$

 Wrap=�6G   �� 5      	 �@��TextAlignment$
 Center=�6H   5      5        5      $ 	Količina��6%    67   �� $ kolicina� 5      �� 5      .�5      �� 	 � ��$

 Wrap=�6G   �� 5      	 �@��TextAlignment$
 Center=�6H   5      5      5!      �� 5"   
   -   5         ��Name$ t1��5"   (   $
��Left=�64   $��	10,10,0,0q�6O   $
��Wrap=�6b   $	��Top=�6v   $��22��6�   $	��250��6�   ��6   �� *S1+6�   �� 5#   
   $��Dodaj��6   $
��Left=�6!   $��
50,371,0,0q�6<   $	��Top=�6P   $��75��6h   ��6s   �� *Dodaj+�� 5$   
   -   5         ��Name$ button5��5$      $��Rasporedjivanje��6"   $
��Left=�6<   $��170,510,0,0q�6W   $	��Top=�6l   $��90��6�   $��20��6�   ��6�   �� *Rasporedjivanje+�� 5%   
   $��Obrisi��6   $
��Left=�6"   $��175,371,0,0q�6=   $	��Top=�6R   $��75��6j   ��6u   �� *Obrisi+�� 5&   
   $��Izmeni��6   $
��Left=�6"   $��300,371,0,0q�6=   $	��Top=�6R   $��75��6j   ��6u   �� *Izmeni+5'      5(      