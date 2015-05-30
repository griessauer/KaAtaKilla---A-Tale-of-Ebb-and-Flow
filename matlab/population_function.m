function [N] = population_function(p, t_max, K)
% Paramaeter
% [Wachstum Blur-Verteilung Reproduktionsverzoegerung Reaktionsverzoegerung]

% init population 
N = ones(max(p(3), p(4)) +1 , 1);

% iteration
for t = size(N,1):t_max-1
    N = [N; max(N(t) + p(1)* N(t-p(3)) * (K(t) - N(t-p(4)))/K(t), 0) + 1];
end

end
