   M S B A M L   `   `   `  ����G  CProjekatSIMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:ProjekatSIMS.Upravnik.ViewProjekatSIMS.Upravnik.View  5      +    %ProjekatSIMS.Upravnik.View.LekoviPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:ProjekatSIMS.Upravnik.View     5        N� Title$  
LekoviPage��5	      $��675.2��6   $	��424��6)   .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGridLekovi��5         SelectionMode$ Single=�5         AutoGenerateColumns .  $
��Left=�6F   $	��300��5      $��	10,47,0,0q�6    $	��Top=�63   $	��400��6K   ��5   +   ��  �� Path$	 Lek�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Sifra leka��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� $ 	sifraleka�   ElementStyle 5      �� 5      .�5      �� 	 �� Property	 � ��
 �� Value$

 Wrap=�6G   �� 5      	 �@��TextAlignment$
 Center=�6H   5      5        5      $ 
Naziv leka��6%    69   �� $ 	nazivleka� 5      �� 5      .�5      �� 	 � ��$

 Wrap=�6G   �� 5      	 �@��TextAlignment$
 Center=�6H   5      5        5       $ Sastojci��6%    67   �� $ sastojci� 5!      �� 5"      .�5#      �� 	 � ��$

 Wrap=�6G   �� 5$      	 �@��TextAlignment$
 Center=�6H   5%      5'        5(      $ Zamena leka��6%    6:   �� $ zamena� 5)      �� 5*      .�5+      �� 	 � ��$

 Wrap=�6G   �� 5,      	 �@��TextAlignment$
 Center=�6H   5-      5/      51      �� 52   
   $��Dodaj��6   $
��Left=�6!   $��
50,380,0,0q�6<   $	��Top=�6P   $��75��6h   ��6s   �� *	Kreiraj+�� 53   
   $��Obrisi��6   $
��Left=�6"   $��170,380,0,0q�6=   $	��Top=�6R   $��75��6j   ��6u   �� *Obrisi+�� 54   
   $��Izmeni��6   $
��Left=�6"   $��290,380,0,0q�6=   $	��Top=�6R   $��75��6j   ��6u   �� *	Promeni+55      56      