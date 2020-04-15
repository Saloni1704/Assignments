create function AddNumber(@firstNumber int,@secondNumber int)
returns int
with execute as 'guest'
as begin
return @firstNumber+@secondNumber;
end

select dbo.AddNumber(1,1) 

grant execute on dbo.AddNumber to guest;

drop function dbo.AddNumber;