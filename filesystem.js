async function saveAs(options, content) {
	var options = JSON.parse(options);
	if (typeof window.showSaveFilePicker === "function") {
		var fileHandle = await window.showSaveFilePicker(options);
		const writable = await fileHandle.createWritable();
		await writable.write(content);
		await writable.close();
	} else {
		var a = document.createElement("a");
		var file = new Blob([content], { type: "text/json" });
		a.href = URL.createObjectURL(file);
		a.download = options.suggestedName;
		a.click();
    }
}