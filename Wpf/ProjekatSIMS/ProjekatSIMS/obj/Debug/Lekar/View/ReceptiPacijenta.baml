   M S B A M L   `   `   `  ����G  CProjekatSIMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:ProjekatSIMS.Lekar.ViewProjekatSIMS.Lekar.View  5      .    (ProjekatSIMS.Lekar.View.ReceptiPacijenta   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:ProjekatSIMS.Lekar.View     5        N� Title$  ReceptiPacijenta��5	      .��5      � 
�������.+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGridRecepti��5         SelectionMode$ Single=�5         AutoGenerateColumns .  $
��Left=�6F   $	��217��5      $��128,207,0,0q�6#   $	��Top=�68   $	��500��6P   $��16(�6_   
��������5   ,   ��  �� Path$ ReceptiSpisak� �� UpdateSourceTrigger$ PropertyChanged=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Sifra Leka��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� $ 	sifraLeka�  5      $ 
Naziv Leka��6%    69   �� $ 	nazivLeka�  5      $ Način uzimanja��6%    6=   �� $ nacinUzimanja�  5      $! Na koliko sati se lek uzima��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 * 6r    6J   �� $ naKolikoSati�6r   5      �� 5   
   $��Dodaj novi recept��6   $
��Left=�6-   $��128,470,0,0q�6H   $	��Top=�6]   $	��190��6u   $��30��6�   $��16(�6�   
�������
��� �����6�   �� *
NoviRecept+6�   �� 5   
   $��JMBG pacijenta��6   $
��Left=�6)   $��128,142,0,0q�6D   $	��Top=�6Y   $��16(�6q   �� 5   
   -   5        
 ��Name$
 t��5   +   $
��Left=�66   $��280,141,0,0q�6Q   $
��Wrap=�6f   $	��Top=�6{   $��32��6�   $	��212��6�   $��16(�6�   $��Italic$�6�   ��6   �� *TJmbg+6�   �� 5   
   $
��🠔��6   $
��Left=�6%   $��	33,33,0,0q�6@   $	��Top=�6T   $��40��6l   $��64��6x   $��30(�6�    J� RenderTransformOrigin$ 0.516,0.533&�6�   
�������
�������
����  ���6�   �� $ Nazad�6  �� 5   
   $��Izdati recepti��6   $
��Left=�6)   $��
128,64,0,0q�6D   $	��Top=�6X   $��22(�6p   5      5      