   M S B A M L   `   `   `  ����G  CProjekatSIMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:ProjekatSIMS.Lekar.ViewProjekatSIMS.Lekar.View  5      "    ProjekatSIMS.Lekar.View.Sale   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:ProjekatSIMS.Lekar.View     5        N� Title$
  Sale��5	      .��5      � 
�������.+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGridProstorije��5         SelectionMode$ Single=�5         AutoGenerateColumns .  $
��Left=�6F   $	��300��5      $��128,141,0,0q�6#   $	��Top=�68   $	��750��6P   ��5   /   ��  �� Path$ 
Prostorije�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$	 Ime��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 150 6Q   1  +System.Windows.Controls.DataGridBoundColumn   Binding 62   �� $	 ime�6Q     5      $ Oznaka��6%   $	 150 6W    65   �� $ oznaka�6W     5      $ Namena��6%   $	 150 6W    65   �� $ namena�6W     5      $ Oprema��6%   $	 150 6W    65   �� $ oprema�	   ElementStyle	 5      �� 5      .�5      �� 
 �� Property
 � �� �� Value$
 Wrap=�6G   �� 5      
 �@��TextAlignment$ Center=�6H   5      5        5      $ Renoviranje��6%   $ * 6a    6:   �� $ renoviranje�6a   5      �� 5   
   $
��Sale��6   $
��Left=�6   $��
128,64,0,0q�6:   $	��Top=�6N   $��22(�6f   �� 5    
   $
��🠔��6   $
��Left=�6%   $��	33,33,0,0q�6@   $	��Top=�6T   $��40��6l   $��64��6x   $��30(�6�    J� RenderTransformOrigin$ 0.516,0.533&�6�   
�������
�������
����  ���6�   �� *Nazad+6�   5"      5#      