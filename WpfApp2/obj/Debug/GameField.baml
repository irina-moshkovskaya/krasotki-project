   M S B A M L   `   `   `  ����B  >WpfApp2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp2WpfApp2  5          WpfApp2.GameField   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:WpfApp2     5        N� Title$  	GameField��5	       N� ShowsNavigationUI .  $	��700��63    N� 
Background �	#FFFBF3CC.��5      � $��0,0,10,0q�6    J� RenderTransformOrigin$ 0.463,0.518&�6    � RowDefinitions 5   
   �� 5      $	��43* �6   �� 5      $
��125* �6   �� 5      $
��232* �6   .+�5   
   �� -   5        $��
GameCanvas��5      $��Center=�6#   $	��528��6@   $��1��6M   $	��Top=�6Z   $	��645��6r   $��
99,13,46,0q�6~   $ 0.5,0.5&�6�   $��2��6�   .+�5      �� -   5        $��FinLbl��5      $��IM INVISIBLE��6"    �� Left$ 10��69   
 �� Top$	 200��6J   $��Center=�6[   $��Center=�6x   $��Center=�6�   $��Center=�6�   $��72(�6�   $	��600��6�   $	��100��6�   $y�Hidden=�6   5      � 5   
   $
��Left=�6   $��99��6*   $	��Top=�66   $	��800��6N   $��	0,0,-10,0q�6Z   $��2��6m    � ColumnDefinitions 5      �� 5      �� 5      .+�5      �� -   5        $��TimeLb��5      $��00:00��6"   $
��Left=�62   $	��Top=�6M   $��53��6e   $	��263��6q   $��1��6}   $��	82,10,0,0q�6�   $$��/WpfApp2;component/#DS-Digital)�6�   $��48(�6�   $��Right=�6�   �� 5      -   5        $��<< Назад��5      $
��Left=�6.   $��	59,10,0,0q�6I   $	��Top=�6\   $	��165��6t   $��63��6�   $��22(�6�   $��Ravie)�6�   ���	#FFC52525��5      �� 5       �� ImageSource$ 
фон.jpg��6!   5      5       �� 5!   
   -   5        	 ��Name$	 button��5!      $+��%Зберегти результати��6!   $��Center=�6?   $��207,187,186,0q�6\   $��2��6s   $	��Top=�6�   $	��397��6�   $��87��6�   $y�Hidden=�6�   ���	#FFC52525$��Raavi)�6�   $��36(�6  ��5"      �� 5#      $ 
фон.jpg��6   5%      5'      5(      