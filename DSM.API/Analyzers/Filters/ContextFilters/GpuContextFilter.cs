namespace DSM.API.Analyzers.Filters.ContextFilters {

	public class GpuContextFilter : Abstract.ContextFilter {

		static readonly string[] Patterns = new string[] {
			"GRAPHICSVISTA: renderer: (?<renderer_api>.+)$",
			"DX11BACKEND: DX11Renderer initialization \\(w:(?<renderer_width>[0-9]+) h:(?<renderer_height>[0-9]+) fullscrn:(?<renderer_fullscreen>[01]) vsync:(?<renderer_vsync>[01]) adapter:(?<renderer_adapter>[0-9]+) monitor:(?<renderer_monitor>[0-9]+) shaderErrors:(?<renderer_shadererrors>[0-9]+)\\)$",
			"DX11BACKEND: (?<gpu_driver>NVIDIA Display Driver) Version (?<gpu_driver_version>[0-9]+\\.r(?<gpu_driver_version_major>[0-9]+)_(?<gpu_driver_version_minor>[0-9]+))$",
			"DX11BACKEND: GPU count:(?<gpu_count>[0-9]+)$",
			"APP: gDescription: (?<gpu_description>.+) gVendorId: (?<gpu_vendorid>[0-9]+) gDeviceId: (?<gpu_deviceid>[0-9]+) gMemory: (?<gpu_vram>[0-9]+) (?<gpu_vram_unit>[A-Z]+)$"
		};

		public GpuContextFilter(Severity? onSeverity) : base(onSeverity, Patterns) { }

	}

}
