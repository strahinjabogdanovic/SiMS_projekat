   M S B A M L   `   `   `  ����G  CProjekatSIMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:ProjekatSIMS.Sekretar.ViewProjekatSIMS.Sekretar.View  5      -    'ProjekatSIMS.Sekretar.View.PageAntiTrol   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:ProjekatSIMS.Sekretar.View     5        N� Title$  PageAntiTrol��5	      $	��649��6   $
��1272��6)    N� 
Background
 ��ح�.��5      � .+�5   
   �� -   5         ��Name$ label��5      $��Blokirani pacijenti��6   $
��Left=�6=   $��
463,59,0,0q�6X   $	��Top=�6l      
TitleStyle#��[  6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGridAntiTrol��5         SelectionMode$ Single=�5         AutoGenerateColumns .  $
��Left=�6F   $	��365��5      $��437,155,0,0q�6    $	��Top=�65   $	��391��6M   $��20(�6Y   ��5   -   ��  �� Path$ TerminiP� �� UpdateSourceTrigger$ PropertyChanged=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Pacijent��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 * 6\   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� $ 	pacijenti�6\   5      �� 5   
   -   5         ��Name$ button��5      $��Nazad��6!   $
��Left=�61   $��688,560,0,0q�6L   $	��Top=�6a     ButtonStyle#��[ 6�   ��6y   �� *Nazad+6�   �� 5   
   -   5        $ button1��5      $��
Odblokiraj��6"   $
��Left=�67   $��437,560,0,0q�6R   $	��Top=�6g   #��[ 6�   ��6   �� *
Odblokiraj+ � ToolTip 5      _� 5      .��6   $"Prvo izaberite pacijenta iz tabele5      5      5      5      