async function saveAs(options, content) {
	var fileHandle = await window.showSaveFilePicker(options);
	const writable = await fileHandle.createWritable();
	await writable.write(content);
	await writable.close();
}