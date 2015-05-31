clear all;
close all;
clc;

res = 10;

x=1:res;
y=x;

m = [150 150]'
nm = norm(m);


[X, Y] = meshgrid(x,y);


figure
Z=zeros(res,res)
for t=1:15
    
    m = [res*cos(pi*t/15) res*sin(pi*t/15)]'
    
    for i=x
        for j=y
            v = [i-res/2;j-res/2];
            Z(j,i) = norm(dot(v,m))/nm;
        end
    end

    Z
    
    subplot(3,5,t)
    contourf(X,Y,Z); hold on;
    plot(m(1),m(2),'x');
    view;
end
