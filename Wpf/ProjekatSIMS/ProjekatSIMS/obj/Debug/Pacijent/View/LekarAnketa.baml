   M S B A M L   `   `   `  ����G  CProjekatSIMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ProjekatSIMSProjekatSIMS  5   	       ProjekatSIMS.LekarAnketa   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:ProjekatSIMS     5   	     � WindowStartupLocation$  CenterScreen=�5   ,    � Title$ LekarAnketa��5   	   $	��500��6   $	��650��6*   
����ح�.��5	      � .+�5
   
   �� $��Ocenjivanje lekara��6   $
��Left=�6-   $��	10,10,0,0q�6H   $	��Top=�6[   $��30(�6s   $	��113��6�   $	��647��6�   $��Italic$�6�   �� 5   
   $��Odaberite lekara:��6   $
��Left=�6,   $��	26,75,0,0q�6G   $	��Top=�6Z   $��25(�6r   �� 5   
   $��Ljubaznost:��6   $
��Left=�6&   $��
26,145,0,0q�6A   $	��Top=�6U   $��25(�6m   �� 5   
   $��
Strucnost:��6   $
��Left=�6%   $��
26,215,0,0q�6@   $	��Top=�6T   $��25(�6l   �� 5   
   $��Vas komentar:��6   $
��Left=�6(   $��
26,275,0,0q�6C   $	��Top=�6W   $��25(�6o   �� 5   
   -   5         ��Name$ cb��5   7   $
��Left=�6C   $��
282,75,0,0q�6^   $	��Top=�6r   $	��303��6�   $��25(�6�    �� SelectedItem 6   ��  �� Path$ Lekar�.@�5      �� .��6   
Jova Jovic6'   �� 5      .��6   Jovan Jovanovic6,   5      � 5   
   .+�5      �� 
���  ��$��16(�6R   $��Center=�6`   $��282,114,57,320q�6}   ��6   �� *ValidationErrors[Lekar]+6}   5      �� 5   
   -   5        $ cbLjub��5   <   $
��Left=�6L   $��282,145,0,0q�6g   $	��Top=�6|   $	��303��6�   $��25(�6�    6   �� $ 
Ljubaznost�.@�5      �� .��6   Nezadovoljan/a6+   �� 5      .��6   Delimicno zadovoljan/a63   �� 5      .��6   Zadovoljan/a6)   5      �� 5   
   -   5        $ cbStr��5   <   $
��Left=�6K   $��282,215,0,0q�6f   $	��Top=�6{   $	��303��6�   $��25(�6�    6   �� $ 	Strucnost�.@�5      �� .��6   Nezadovoljan/a6+   �� 5      .��6   Delimicno zadovoljan/a63   �� 5      .��6   Zadovoljan/a6)   5      �� 5    
   -   5         ��Name$
 comm��5    1   $
��Left=�6?   $��82��6Z   $��225,283,0,0q�6f    �� TextWrapping$
 Wrap=�6{   " �� VerticalScrollBarVisibility$
 Auto=�6�    �� AcceptsReturn . 	 �� MinLines$	 1��6�   
 �� MaxLines$
 4��6�   $	��Top=�6�   $	��360��6�   $��25(�6  ��6   �� $ Komentar�6  �� 5!   
   $��Odustani��6   $
��Left=�6$   $��130,395,0,0q�6?   $	��Top=�6T   $	��160��6l   $��25(�6x   $��44��6�    J� RenderTransformOrigin$ 0.506,0.864&�6�   ��6�   �� *OdustaniOdAnkete+�� 5"   
   $��Potvrdi��6   $
��Left=�6#   $��354,395,0,0q�6>   $	��Top=�6S   $	��160��6k   $��25(�6w   $��44��6�   ��6�   �� *PotvrdiAnketu+� 5#   
   .+�5$      �� 
���  ��$��16(�6W   $��Center=�6e   $��282,184,57,250q�6�   ��6   �� *ValidationErrors[Ljubaznost]+6�   5%      � 5&   
   .+�5'      �� 
���  ��$��16(�6V   $��Center=�6d   $��282,254,57,178q�6�   ��6   �� *ValidationErrors[Strucnost]+6�   5(      � 5)   
   .+�5*      �� 
���  ��$��16(�6U   $��Center=�6c   $��225,364,57,80q�6�   ��6   �� *ValidationErrors[Komentar]+6�   5+      5,      5-      