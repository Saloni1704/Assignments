declare @xmldata xml;
set @xmldata ='<orders>
	<order id="ord123457">
		<customer id="cust0067">
			<first-name>Shai</first-name>
			<last-name>Bassli</last-name>
			<address>
				<street>567 3rd Ave</street>
				<city>Saginaw</city>
				<state>MI</state>
				<zip>53900</zip>
			</address>
		</customer>
	</order>
</orders>';

select  @xmldata as XmlColumn;