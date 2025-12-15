// Dark mode toggle functionality
(function() {
    'use strict';

    // Initialize dark mode based on localStorage or system preference
    function initDarkMode() {
        const darkModeToggle = document.getElementById('dark-mode-toggle');
        if (!darkModeToggle) return;

        const sunIconGH = document.querySelector('.sun-icon-github');
        const moonIconGH = document.querySelector('.moon-icon-github');
        const sunIcon = darkModeToggle.querySelector('.sun-icon');
        const moonIcon = darkModeToggle.querySelector('.moon-icon');
        
        // Check for saved theme preference or default to system preference
        const savedTheme = localStorage.getItem('theme');
        const prefersDark = window.matchMedia('(prefers-color-scheme: dark)').matches;
        
        if (savedTheme === 'dark' || (!savedTheme && prefersDark)) {
            document.documentElement.classList.add('dark');
            if (sunIconGH) sunIconGH.style.display = 'none';
            if (moonIconGH) moonIconGH.style.display = 'block';
            if (sunIcon) sunIcon.style.display = 'none';
            if (moonIcon) moonIcon.style.display = 'block';
        } else {
            document.documentElement.classList.remove('dark');
            if (sunIconGH) sunIconGH.style.display = 'block';
            if (moonIconGH) moonIconGH.style.display = 'none';
            if (sunIcon) sunIcon.style.display = 'block';
            if (moonIcon) moonIcon.style.display = 'none';
        }
    }

    // Toggle dark mode
    function toggleDarkMode() {
        const darkModeToggle = document.getElementById('dark-mode-toggle');
        if (!darkModeToggle) return;

        const sunIconGH = document.querySelector('.sun-icon-github');
        const moonIconGH = document.querySelector('.moon-icon-github');
        const sunIcon = darkModeToggle.querySelector('.sun-icon');
        const moonIcon = darkModeToggle.querySelector('.moon-icon');
        const isDark = document.documentElement.classList.toggle('dark');
        
        if (isDark) {
            localStorage.setItem('theme', 'dark');
            if (sunIconGH) sunIconGH.style.display = 'none';
            if (moonIconGH) moonIconGH.style.display = 'block';
            if (sunIcon) sunIcon.style.display = 'none';
            if (moonIcon) moonIcon.style.display = 'block';
        } else {
            localStorage.setItem('theme', 'light');
            if (sunIconGH) sunIconGH.style.display = 'block';
            if (moonIconGH) moonIconGH.style.display = 'none';
            if (sunIcon) sunIcon.style.display = 'block';
            if (moonIcon) moonIcon.style.display = 'none';
        }
    }

    // Initialize on page load
    if (document.readyState === 'loading') {
        document.addEventListener('DOMContentLoaded', initDarkMode);
    } else {
        initDarkMode();
    }

    // Add click event listener
    window.addEventListener('load', function() {
        const darkModeToggle = document.getElementById('dark-mode-toggle');
        if (darkModeToggle) {
            darkModeToggle.addEventListener('click', toggleDarkMode);
        }
    });
})();
