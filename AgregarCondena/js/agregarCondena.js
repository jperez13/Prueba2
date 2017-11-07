$(document).ready(function() {

	//apenas se cargue la pagina cargamos los Presos
	//en el select

	var peticionPresos = $.get("http://localhost:51253/api/presoes");

	peticionPresos.done(function(respuesta) {
		//si trajo los datos creamos los option
		var html = "<option value=''>Seleccionar Preso</option>";
		respuesta.forEach(function(item) {
			html+="<option value='"+item.Id+"'>" + item.Nombre + "</option>";
		});
		//le pasamos el html generado al select
		$("#cboPreso").html(html);
	});

	peticionPresos.fail(function(xhr) {
		//fallo la peticion
	});

	//apenas se cargue la pagina cargamos los Jueces
	//en el select
	var peticionJueces = $.get("http://localhost:51253/api/juezs");

	peticionJueces.done(function(respuesta) {
		//si trajo los datos creamos los option
		var html = "<option value=''>Seleccionar Juez</option>";
		respuesta.forEach(function(item) {
			html+="<option value='"+item.Id+"'>" + item.Nombre + "</option>";
		});
		//le pasamos el html generado al select
		$("#cboJuez").html(html);
	});

	peticionJueces.fail(function(xhr) {
		//fallo la peticion
	});


	//apenas se cargue la pagina cargamos los Presos
	//en el select

	var peticionDelitos = $.get("http://localhost:51253/api/delitoes");

	peticionDelitos.done(function(respuesta) {
		//si trajo los datos creamos los option
		var html = "<option value=''>Seleccionar Delito</option>";
		respuesta.forEach(function(item) {
			html+="<option value='"+item.Id+"'>" + item.Nombre + "</option>";
		});
		//le pasamos el html generado al select
		$("#cboDelitos").html(html);
	});

	peticionDelitos.fail(function(xhr) {
		//fallo la peticion
	});


	$("#btnGuardar").on('click', function() {
		//Cuando se hace click en el boton guardar 
		//se ejecuta el siguiente codigo

		// paso 1 : recuperar datos
		var fechaInicio = $("txtFechaInicio").val();
		var fechaRegistro = $("txtFechaCondena").val();
		var presoId = $("#cboPreso").val();
		var juezId = $("#cboJuez").val();
		var delitosId = $("#cboDelitos").val();
		var cantidadAnios = $("#txtAnios").val();

		// paso 2 : armar el json a enviar

		var dataCondena = {
			FechaInicioCondena:fechaInicio,
			FechaCondena:fechaRegistro,
			PresoId:presoId,
			JuezId:juezId,
			DelitosCondenas:[
			{
				DelitoId = delitosId,
				AniosCondena = cantidadAnios
			}]
			
		}

		//paso 3: Enviar el json al webservice
		var peticionAgregar = $.post("http://localhost:55681/api/condenas", dataCondena);

		peticionAgregar.done(function(respuesta){
			$("#lblMensaje").html("Agregado correctamente");
		});

		peticionAgregar.fail(function(xhr) {
			$("#lblMensaje").html("Error al agregar");
		});

	});

});