   M S B A M L   `   `   `  ����G  CProjekatSIMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:ProjekatSIMS.Sekretar.ViewProjekatSIMS.Sekretar.View  5      /    )ProjekatSIMS.Sekretar.View.PageProstorije   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:ProjekatSIMS.Sekretar.View     5        N� Title$  PageProstorije��5	      $	��649��6   $
��1272��6+    N� 
Background
 ��ح�.��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGridProstorije��5         SelectionMode$ Single=�5         AutoGenerateColumns .  $
��Left=�6F   $	��383��5      $��
44,155,0,0q�6    $	��Top=�64   $
��1187��6L   $��20(�6Y   ��5   /   ��  �� Path$ 
Prostorije�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$	 Ime��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 160 6Q   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 62   �� $	 ime�6Q     5      $ Oznaka��6%   $	 160 6W   	 65   �� $ oznaka�6W     5      $ Namena��6%   $	 180 6W   	 65   �� $ namena�6W     5      $ Oprema��6%   $	 350 6W   	 65   �� $ oprema�
   ElementStyle
 5      �� 5      .�5      ��  �� Property � �� �� Value$
 Wrap=�6G   �� 5       �@��TextAlignment$ Center=�6H   5      5        5      $ Renoviranje��6%   $ * 6a   	 6:   �� $ renoviranje�6a   5      �� 5    
   -   5         ��Name$ label��5       $��
Prostorije��6   $
��Left=�64   $��	44,68,0,0q�6O   $	��Top=�6b      
TitleStyle#��[  6z   �� 5!   
   -   5         ��Name$ button��5!      $��Nazad��6!   $
��Left=�61   $��538,568,0,0q�6L   $	��Top=�6a     ButtonStyle#��[ 6�   ��6y   �� *Nazad+6�   �� 5"   
   -   5        $ button1��5"      $$��Grafikon zauzetosti prostorija��6"   $
��Left=�6K   $��
899,84,0,0q�6f   $	��Top=�6z   $	��335��6�   #��[ 6�   ��6�   �� *
Grafikon+6�   5#      5$      