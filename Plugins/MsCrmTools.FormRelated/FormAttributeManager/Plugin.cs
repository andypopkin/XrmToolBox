﻿using System.ComponentModel.Composition;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace MsCrmTools.FormAttributeManager
{
    [Export(typeof(IXrmToolBoxPlugin)),
      ExportMetadata("Name", "Bulk Form Attribute Manager"),
      ExportMetadata("Description", "Apply bulk modifications to forms fields"),
      ExportMetadata("SmallImageBase64", "iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAA/hpVFh0WE1MOmNvbS5hZG9iZS54bXAAAAAAADw/eHBhY2tldCBiZWdpbj0i77u/IiBpZD0iVzVNME1wQ2VoaUh6cmVTek5UY3prYzlkIj8+IDx4OnhtcG1ldGEgeG1sbnM6eD0iYWRvYmU6bnM6bWV0YS8iIHg6eG1wdGs9IkFkb2JlIFhNUCBDb3JlIDUuMy1jMDExIDY2LjE0NTY2MSwgMjAxMi8wMi8wNi0xNDo1NjoyNyAgICAgICAgIj4gPHJkZjpSREYgeG1sbnM6cmRmPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5LzAyLzIyLXJkZi1zeW50YXgtbnMjIj4gPHJkZjpEZXNjcmlwdGlvbiByZGY6YWJvdXQ9IiIgeG1sbnM6eG1wTU09Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC9tbS8iIHhtbG5zOnN0UmVmPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvc1R5cGUvUmVzb3VyY2VSZWYjIiB4bWxuczpkYz0iaHR0cDovL3B1cmwub3JnL2RjL2VsZW1lbnRzLzEuMS8iIHhtbG5zOnhtcD0iaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wLyIgeG1wTU06T3JpZ2luYWxEb2N1bWVudElEPSJ1dWlkOjY1RTYzOTA2ODZDRjExREJBNkUyRDg4N0NFQUNCNDA3IiB4bXBNTTpEb2N1bWVudElEPSJ4bXAuZGlkOjFGNTVDRDJBOTY4QTExRTU4OTkxREE4RTkwMDk1NDkxIiB4bXBNTTpJbnN0YW5jZUlEPSJ4bXAuaWlkOjFGNTVDRDI5OTY4QTExRTU4OTkxREE4RTkwMDk1NDkxIiB4bXA6Q3JlYXRvclRvb2w9IkFkb2JlIFBob3Rvc2hvcCBDUzYgV2luZG93cyI+IDx4bXBNTTpEZXJpdmVkRnJvbSBzdFJlZjppbnN0YW5jZUlEPSJ4bXAuaWlkOmVhNTRlMmQ2LWIzMjAtNWI0OS04MmJiLWFjYjAzZjExZWNiOSIgc3RSZWY6ZG9jdW1lbnRJRD0iYWRvYmU6ZG9jaWQ6cGhvdG9zaG9wOmUzOWI3YWQ2LThjNzktMTFlNS05ODhjLWRiZjc4MmM1NTRjNSIvPiA8ZGM6dGl0bGU+IDxyZGY6QWx0PiA8cmRmOmxpIHhtbDpsYW5nPSJ4LWRlZmF1bHQiPmFpPC9yZGY6bGk+IDwvcmRmOkFsdD4gPC9kYzp0aXRsZT4gPC9yZGY6RGVzY3JpcHRpb24+IDwvcmRmOlJERj4gPC94OnhtcG1ldGE+IDw/eHBhY2tldCBlbmQ9InIiPz5fUFSmAAAGSUlEQVR42rRXe1BUZRQ/e/fuCxZcYR+8lVaFwPcL2SgfY2kWWJbkNFYiKlZaSlE4SSn5qHFKBQxiQmYwaSSmP5zSycZUTGCUkXyA+AR5vxdZ3F32sns7F3aXy91dIKxv5nzf/c73OOc73znn+12SpmmwFd5HJTCGIkZyR+qwcwgeQE0PHEueAWvnKJwu6jp3Ae4nfQoEPHkJRgoZPAVSDwWgFMPcQOmIi/8LBSKQpgBbg45eOLBGDaFKyYiLeVzG9u3b17u5uUXjJ0lRVInRaCxMS0u743KHxOI0rG/Bt5rMf6t52ZwIRwsYDAaNRCJ5BZV4WSaT7fX29r69ZcuWrGH2eR5JPxbTEUKhowJZWVkbWlpa9tn6QpwUEBCQkJSUlOvk9P5YhyK1DicIHV3ojE91dgKxbds2WXx8fHhcXJzdY9LT0z9ramraxZ4sl8vXoSVe4uzxorXVDSM8eqiPDBb9nTsYMDxeDJr5pqen52H2YEZGxu7m5uZ9bB5ezeucPVZbW4sL4UyIbmSiztm40McPCJFIFIEEXl5e67du3XqAPcFkMu3p7e1ttvUFAsFElvk9sF7qypmt5V2kaDxkvbNB0kMKhNls7ujr6+tnKJXKj1GJ71lznkWhPvY7o6ha1throwjjL5hlLq/HbAYST3gaN35DLBZPsSqxKTk5eSaGXxlGQSxBDMrAk5Cs9QkjON472IzrD9GR8gA64YdBQUGHbMJQkAPZ+OicOw8RsT9j9zZrlyj4RnOJJZyPTTuSDOkGrpvOFVyqDv2cSeH9EnNycg6jw301mtj18/Pbs5IoLRzCNDn44HdW4U6zbemkp9/CZjeznX0wMzNzR11d3WKtVntSr9ff1el0FT09PVUWi8XM3SBKZZ62gl/OellMbNNrsNnk6gClwSHROCnP2r3NvlPIzs4+j815Nm/z5s3zVCrVCQzBYDZ/icoAbu1XoJCaD2DsI63CmfYXV8LPgXApkPyTYLFbTDTiY4SZ8Qre+2y0SBV3LFLRB28KSgEUEq2VVYCk4kxj/AHOAkyVqNV/sISP/jVEy3S1tbVFNnebOrljc5U0JI8/k4qnj8Xuqw7RYDHXlS9dxkTYRR5JjP05zpauozMMC2UPHtEOY0rv8SsLCgpOOFtnamrq6CkvT5b4TpTRfQ7uRP8bPJBGAUlkG56BSq1j4mtsbIT8/HzHVWaLECw0z1WuHJ0CicWzsH57IOkTkGvUwLUOx6V4TZCXl8eRQNA8kjQBTT8RIvqJyzjWuwCutJOOWK+rC3Jzc6G6uhq6u7uhur5+XKfcSzZqROTk9KlYp7haHWsp1S8IBDdnmZMBvPZ+axuoiksgqKaOvcOX/BGEM3jv2HCJvKLFu3ahqqNWQNA+XCWY1G5rCQ8PMISHQafBAMrmFtsORcQwwhmo/ZtLuzFXakSv1lG+oVGxhf7+/qO6y94li6DZ33dUPnAGyduO82kr3G5E+NdoMIPOfN3LU3zNb7JPvrdaJYyJiQE+f6hBfX19YZpaXWZ6WNsy6JMEtIaGQHvAgMKki9MzGU0zkMcIRiCAVNIxeZa6bFGYf11kMNwLEsIjjQqaaa1OTrXfnWpoo06ZKWoJj88X9+dYgUC7atWqSrNef0Gw8T3v61GaBHph1ACumBAIj41GkNc3OFEgsfioHWox71Avr/KF1dOP7pgurpzffV/kdv/PELjZQD6+XLa8ixYbdTUPRW0VtyydUpmh7/0EocBqBeOtKqpyzVqtqa1VwSP5y2deLoMKdEpq8XMD1rQmJZIjnMGAcdZeNfDc98KR2TlnjgD8vnrZsr/Plim6OjvuYTY3ETzhZZzjKZDJ9KRUZpGbaQKfzwiBSBTQ7yaT1MqLlVWBoRcvycQTJjDhAOFlV+GquwTTGQHujU0DEIOjwA2spyIxiuzCn41+OIWATvSAdBcJAvx0kTV3aVdOg9D9E4TwX7MjoaGhYef+/fv3IgB5CqfMYN4wpMXMM4J0hKsAnhWKUfDxsf6npaSknFYoFMvZ+aC1tTU9NTX1Aw4iCmcS9VC3jYwXYP0rlOT0jVWBoqKi4+Hh4VKMiHmoAJ/xeqlUGhEWFtZbXFz8l23eD9r2tg1e8nYe/E/l4MGDKxBtr8BPN/5AZPyYmJh4igNc4R8BBgApzU5ZPFouIQAAAABJRU5ErkJggg=="),
      ExportMetadata("BigImageBase64", "iVBORw0KGgoAAAANSUhEUgAAAGQAAABkCAYAAABw4pVUAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAA/hpVFh0WE1MOmNvbS5hZG9iZS54bXAAAAAAADw/eHBhY2tldCBiZWdpbj0i77u/IiBpZD0iVzVNME1wQ2VoaUh6cmVTek5UY3prYzlkIj8+IDx4OnhtcG1ldGEgeG1sbnM6eD0iYWRvYmU6bnM6bWV0YS8iIHg6eG1wdGs9IkFkb2JlIFhNUCBDb3JlIDUuMy1jMDExIDY2LjE0NTY2MSwgMjAxMi8wMi8wNi0xNDo1NjoyNyAgICAgICAgIj4gPHJkZjpSREYgeG1sbnM6cmRmPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5LzAyLzIyLXJkZi1zeW50YXgtbnMjIj4gPHJkZjpEZXNjcmlwdGlvbiByZGY6YWJvdXQ9IiIgeG1sbnM6eG1wTU09Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC9tbS8iIHhtbG5zOnN0UmVmPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvc1R5cGUvUmVzb3VyY2VSZWYjIiB4bWxuczpkYz0iaHR0cDovL3B1cmwub3JnL2RjL2VsZW1lbnRzLzEuMS8iIHhtbG5zOnhtcD0iaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wLyIgeG1wTU06T3JpZ2luYWxEb2N1bWVudElEPSJ1dWlkOjY1RTYzOTA2ODZDRjExREJBNkUyRDg4N0NFQUNCNDA3IiB4bXBNTTpEb2N1bWVudElEPSJ4bXAuZGlkOjEwQjA1RkVDOTY4QTExRTVBQ0RCREZDQjgxMjdEQzYyIiB4bXBNTTpJbnN0YW5jZUlEPSJ4bXAuaWlkOjEwQjA1RkVCOTY4QTExRTVBQ0RCREZDQjgxMjdEQzYyIiB4bXA6Q3JlYXRvclRvb2w9IkFkb2JlIFBob3Rvc2hvcCBDUzYgV2luZG93cyI+IDx4bXBNTTpEZXJpdmVkRnJvbSBzdFJlZjppbnN0YW5jZUlEPSJ4bXAuaWlkOmVhNTRlMmQ2LWIzMjAtNWI0OS04MmJiLWFjYjAzZjExZWNiOSIgc3RSZWY6ZG9jdW1lbnRJRD0iYWRvYmU6ZG9jaWQ6cGhv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"),
      ExportMetadata("BackgroundColor", "Lavender"),
      ExportMetadata("PrimaryFontColor", "Black"),
      ExportMetadata("SecondaryFontColor", "Gray")]
    public class Plugin : PluginBase
    {
        public override IXrmToolBoxPluginControl GetControl()
        {
            return new MainControl();
        }
    }
}