   M S B A M L   `   `   `  ����G  CProjekatSIMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:ProjekatSIMS.Lekar.ViewProjekatSIMS.Lekar.View  5      *    $ProjekatSIMS.Lekar.View.UputBolnicko   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:ProjekatSIMS.Lekar.View     5        N� Title$  UputBolnicko��5	      .��5      � 
�������.+�5   
   �� $��Zdravstvena ustanova��6   $
��Left=�6/   $��128,122,0,0q�6J   $	��Top=�6_   $��16(�6w   $��33��6�   �� 5   
   $��Zdravo klinika Novi Sad��6   $
��Left=�62   $��308,122,0,0q�6M   $	��Top=�6b   $	��185��6z   $��16(�6�   $��Italic$�6�   $��33��6�   �� 5   
   $��Zdravstvenoj ustanovi��6   $
��Left=�60   $��550,122,0,0q�6K   $	��Top=�6`   $	��170��6x   $��33��6�   $��16(�6�   �� 5   
   $,��&Broj zdravstvenog 
kartona - protokola��6   $
��Left=�6E   $��132,164,0,0q�6`   $	��Top=�6u   $��51��6�   $	��163��6�   $��16(�6�   �� 5   
   -   5         ��Name$ tBox2��5   2   $
��Left=�6A   $��33��6\   $��308,172,0,0q�6h    �� TextWrapping$
 Wrap=�6}   $	��Top=�6�   $	��208��6�   ��6   �� *TBrojProtokola+6�   �� 5   
   -   5         ��Name$ tBlock1��5      $
��Left=�6%   $��308,222,0,0q�6@   $
��Wrap=�6U   $	��Top=�6�   $��33��6�   $	��208��6�   $��16(�6�   $��Italic$�6�   ��6i   �� *	TPacijent+6�   �� 5   
   -   5        $ tBlock2��5      $
��Left=�6%   $��308,272,0,0q�6@   $
��Wrap=�6U   $	��Top=�6�   $��33��6�   $	��208��6�   $��16(�6�   $��Italic$�6�   ��6i   �� *TJmbg+6�   �� 5   
   $��Upućuje se��6   $
��Left=�6%   $��128,222,0,0q�6@   $	��Top=�6U   $��33��6m   $	��125��6y   $��16(�6�   �� 5   
   $
��JMBG��6   $
��Left=�6   $��128,272,0,0q�6:   $	��Top=�6O   $��33��6g   $	��125��6s   $��16(�6   �� 5   
   $��Zdravo klinici Novi Sad��6   $
��Left=�62   $��750,122,0,0q�6M   $	��Top=�6b   $	��178��6z   $��16(�6�   $��Italic$�6�   $��33��6�   �� 5   
   $
��Soba��6   $
��Left=�6    $��128,322,0,0q�6;   $	��Top=�6P   $��42��6h   
�������
�������$��33��6�   $��16(�6�   ��6�   ��  �� Path$
 Soba�6�   �� 5   
   -   5        $ tSoba��5   )   $
��Left=�68   $��33��6S   $��308,322,0,0q�6_   $
 Wrap=�6t   $	��Top=�6�   $	��208��6�   $��16(�6�   $��Italic$�6�   ��6   �� *TSoba+6�   �� 5   
   $��Krevet��6   $
��Left=�6!   $��128,372,0,0q�6<   $	��Top=�6Q   $��33��6i   $	��125��6u   $��16(�6�   �� 5   
   -   5        $ tKrevet��5   +   $
��Left=�6<   $��33��6W   $��308,372,0,0q�6c   $
 Wrap=�6x   $	��Top=�6�   $	��208��6�   $��16(�6�   $��Italic$�6�   ��6   �� *	TKrevet+6�   �� 5   
   $��Datum dolaska��6   $
��Left=�6(   $��128,422,0,0q�6C   $	��Top=�6X   $��33��6p   $	��125��6|   $��16(�6�   (  "System.Windows.Controls.DatePicker  5   
   $
��Left=�5      $��308,422,0,0q�62   $	��Top=�6G   $��30��6_   $	��208��6k   $��16(�6w   $��Italic$�6�      SelectedDate 5      �� $ DatumDolaska� �� Mode$ TwoWay=�5   �   �� 5    
   $��Datum odlaska��6   $
��Left=�6(   $��128,472,0,0q�6C   $	��Top=�6X   $��33��6p   $	��125��6|   $��16(�6�     5!   
   $
��Left=�5$      $��308,472,0,0q�62   $	��Top=�6G   $��33��6_   $	��208��6k   $��16(�6w   $��Italic$�6�    5"      �� $ DatumOdlaska�$ TwoWay=�5$   �   �� 5%   
   $��	Dijagnoza��6   $
��Left=�6$   $��128,522,0,0q�6?   $	��Top=�6T   $��33��6l   $	��125��6x   $��16(�6�   �� 5&   
   -   5        $ 
tDijagnoza��5&   .   $
��Left=�6B   $��33��6]   $��308,522,0,0q�6i   $
 Wrap=�6~   $	��Top=�6�   $	��592��6�   $��16(�6�   $��Italic$�6�   ��6   �� *
TDijagnoza+6�   �� 5'   
   $��Sačuvaj��6   $
��Left=�6#   $��128,592,0,0q�6>   $	��Top=�6S   $	��190��6k   $��30��6w   
��� ���
��� ���$��16(�6�   ��6�   �� *SacuvajUput+6�   �� 5(   
   $ ��Uput za bolničko lečenje��6   $
��Left=�63   $��
128,64,0,0q�6N   $	��Top=�6b   $��22(�6z   �� 5)   
   $
��🠔��6   $
��Left=�6   $��	33,33,0,0q�69   $	��Top=�6M   $��40��6e   $��64��6q   $��30(�6|    J� RenderTransformOrigin$ 0.516,0.533&�6�   
�������
�������
����  ���6�   �� *Nazad+6�   5+      5,      