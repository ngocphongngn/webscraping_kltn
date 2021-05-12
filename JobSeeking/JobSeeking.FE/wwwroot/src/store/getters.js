const getters = {
  sidebar: (state) => state.app.sidebar,
  size: (state) => state.app.size,
  device: (state) => state.app.device,
  errorLogs: (state) => state.errorLog.logs,
  data: (state) => state.taxPeriod.data,
  dataOfRow: (state) => state.taxPeriod.dataOfRow,
  filter: (state) => state.filter.filter,
};
export default getters;
