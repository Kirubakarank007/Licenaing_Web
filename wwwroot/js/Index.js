
function switchTab(tabId) {
	const premises = document.getElementById('premises');
	const personal = document.getElementById('personal');
	const text = document.getElementById('text-holder').getAttribute('placeholder');

	// Remove 'active' class from all tabs and contents
	document.querySelectorAll('.tab, .content').forEach(el => el.classList.remove('active'));

	// Add 'active' class to selected tab and content
	document.querySelector(`.tab-container .tab:nth-child(${tabId === 'premises' ? 1 : 2})`).classList.add('active');
	document.getElementById(tabId).classList.add('active');

	if (tabId === 'premises') {
		document.getElementById('text-holder').setAttribute('placeholder', "Branch Number, Post Code, Lincense Number, Branch Name....");
	} else if (tabId === 'personal') {
		document.getElementById('text-holder').setAttribute('placeholder', "Employee Number, Lincense Number, Employee Name, Employee Pos ");
	}
}