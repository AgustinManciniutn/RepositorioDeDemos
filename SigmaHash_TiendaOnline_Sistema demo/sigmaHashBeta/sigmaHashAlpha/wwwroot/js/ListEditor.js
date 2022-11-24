$(document).ready(() => {

	let pics = document.querySelector('.listicons');
	var selected;
	const icons = pics.children;

	let editor = document.querySelector('#editor');

	var perc = 0;

	function compact() {

		setTimeout(function () {

			$('.formholder').on('keyup keypress', function (e) {
				var keyCode = e.keyCode || e.which;
				if (keyCode === 13) {
					e.preventDefault();
					return false;
				}
			});
			$('#priceinput').ready(function () {
				$('.priceinput').blur(function () {
					var num = parseFloat($(this).val());
					var cleanNum = num.toFixed(2);
					$(this).val(cleanNum);
				});
			});



			let gallery = document.querySelector('#gallerypics');
			// Multiple images preview in browser
			function Previewer(input, placeToInsertImagePreview) {
				$(placeToInsertImagePreview).html("");
				if (input.files) {
					var filesAmount = input.files.length;

					for (i = 0; i < filesAmount; i++) {
						var reader = new FileReader();

						reader.onload = function (event) {
							$($.parseHTML('<img>')).attr('src', event.target.result).appendTo(placeToInsertImagePreview);
						}

						reader.readAsDataURL(input.files[i]);
						('.onepic label').css('border-color', 'red');
					}
				}



			};

			$('.formimages').on('change', '#addpic1', function () {
				let target = $('#gal1');
				Previewer(this, target);

			});
			$('.formimages').on('change', '#addpic2', function () {
				let target = $('#gal2');
				Previewer(this, target);

			});
			$(document).on('change', '#addpic3', function () {
				let target = $('#gal3');
				Previewer(this, target);

			});
			$(document).on('change', '#addpic4', function () {
				let target = $('#gal4');
				Previewer(this, target);
			});
			$(document).on('change', '#addpic5', function () {
				let target = $('#gal5');
				Previewer(this, target);
			});

			$(document).on('change', '#addpic6', function () {
				let target = $('#gal6');
				Previewer(this, target);
			});


			let slider = document.querySelector('.prodslider');

			var p = 0;

			$('.onepic').each(function () {
				let k = -450 * p;
				let s = k + 'px'
				this.addEventListener('mouseover', function () {

					$('.prodslider').css('margin-left', s);
					console.log(k);
				});
				console.log(p);
				p++;
			});
			var gal = 1;
			var ap = 1;
			$('.imgdlt').each(function () {

				let k = '#addpic' + ap.toString();
				let p = '#gal' + gal.toString();
				this.addEventListener('click', function () {
					document.querySelector(k).value = "";
					$(p).html("");
				});
				ap++;
				gal++;
			});
		});
	}

	for (let obj of icons) {

		let temp = perc;
		$(obj).on('click', function () {
			if (selected != null) {
				selected.style.filter = "contrast(0)";
				selected.style.scale = "1";
			}
			pics.style.background = "linear-gradient(to right, #cecece, #ffffff " + temp + "%, #cecece)";
			selected = obj;
			selected.style.filter = "contrast(1)";
			obj.style.scale = "1.3";

			let id = obj.id;
			$.ajax({
				type: "POST",
				url: "/MOT/Editor",
				data: { id: id },

			}).done(function (result) {
				$('#editor').html(result);
				compact();
			});

		});
		perc += 10;
	}



});