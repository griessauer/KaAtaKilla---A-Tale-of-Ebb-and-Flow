clear all;
close all;
clc

res = 10;
sta = 1;

x = 1:res;
y = 1:res;

[X, Y] = meshgrid(x,y);
G = zeros(res,res);

for i = x
    for j = y
        G(i,j) = exp(-((i-1)^2+(j-1)^2)/(2*sta));
    end
end

G = G.*(1/(2*pi*sta))

% Z = (1/(2*pi*sta))*exp(-(X^2+Y^2)/(2*sta));

% Z = eye(res,res);

% Z = sign(conv2(eye(res,res), ones(3),'same'));

% Z = ones(res,res);

% Z = zeros(res,res);

% Z(res/2,res/2) = 0.3;

figure
surf(X,Y,G)

% Paramaeter
% [Wachstum Blur-Verteilung Reproduktionsverzoegerung Reaktionsverzoegerung]


p = [0.1 1 2 1]';


t_max = 100;

N = zeros(res, res, t_max);



% K = [flipud((1:t_max/2)') + 25; 25*ones(t_max/2, 1)];

K = ones(res, res);

K(res/2, res/2) = 100;
K(res/2+1, res/2+3) = 100;


figure
surf(X,Y,K)

figure
surf(X,Y,N(:,:,1))

blur = 2;
b = -blur:blur;

for t = max(p(3),p(4))+2:t_max
    Z = zeros(res,res);
    for i=x
        for j=y
            N(i,j,t) = max(N(i,j,t-1) + 1 + p(1)* N(i,j,t-1-p(3)) * (K(i,j) - N(i,j,t-1-p(4)))/K(i,j), 0);
            if(N(i,j,t) > 0)
                for i2 = b
                    for j2 = b
                        i_f = mod(i+i2-1,res)+1;
                        j_f = mod(j+j2-1,res)+1;
                        Z(i_f,j_f) = Z(i_f,j_f) + N(i,j,t) * G(abs(i2)+1, abs(j2)+1);
                    end
                end
            end
        end
    end
    N(:,:,t) = N(:,:,t) + Z;
end

size(N)
figure
contourf(X,Y,N(:,:,t_max))


figure
for i=1:20
    subplot(4,5,i);
    surf(X,Y,N(:,:,i))
end