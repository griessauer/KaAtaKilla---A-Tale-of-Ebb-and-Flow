clear all;
close all;
clc

% Paramaeter
% [Wachstum Blur-Verteilung Reproduktionsverzoegerung Reaktionsverzoegerung]


p = [0.1 1 5 1]'


t_max = 100;

% Stagnation
K1 = 1:t_max;
K1 = K1';

K2 = [50 * ones(t_max/4, 1) ; zeros(t_max/4, 1)];
K2 = [K2;K2];

K3 = 100* ones(t_max, 1);

K4 = [flipud((1:t_max/2)') + 25; 25*ones(t_max/2, 1)];

N1 = population_function(p, t_max, K1);
N2 = population_function(p, t_max, K2);
N3 = population_function(p, t_max, K3);
N4 = population_function(p, t_max, K4);

figure
plot(1:t_max, K1, 1:t_max, N1)

figure
plot(1:t_max, K2, 1:t_max, N2)

figure
plot(1:t_max, K3, 1:t_max, N3)

figure
plot(1:t_max, K4, 1:t_max, N4)