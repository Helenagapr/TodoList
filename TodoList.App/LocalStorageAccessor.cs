
using Microsoft.JSInterop;
using System.Text.Json;

namespace TodoList.App {
    public class LocalStorageAccessor : IAsyncDisposable
    {
        // get        
        public async Task<T> GetValueAsync<T>(string key)
        {
            await WaitForReference();
            var jsonResult = await _accessorJsRef.Value.InvokeAsync<string>("get", key);
            var result = JsonSerializer.Deserialize<T>(jsonResult);
            return result;
        }

        // set
        public async Task SetValueAsync<T>(string key, T value) { // T tipus generic, podria ser qualsevol lletra, no té T al inici perquè no té return 
            await WaitForReference();
            string jsonValue = JsonSerializer.Serialize(value);
            await _accessorJsRef.Value.InvokeVoidAsync("set", key, jsonValue); // el valor que le queremos cambiar
            
        }

        // remove
        public async Task RemoveValueAsync(string key) { //  no té T al inici perquè no té return
            await WaitForReference();
            await _accessorJsRef.Value.InvokeVoidAsync("remove", key);
            
        }

        // clear: buida tot el que hi hagui al local Storage
        public async Task ClearValueAsync() {  // no té T al inici perquè no té return ni accecta cap parametre
            await WaitForReference();
            await _accessorJsRef.Value.InvokeVoidAsync("clear");
            
        }

        private Lazy<IJSObjectReference> _accessorJsRef = new(); //no tindrà valor fins que ho cridem
        private readonly IJSRuntime _jsRuntime;
        public LocalStorageAccessor(IJSRuntime jSRuntime) {
            _jsRuntime= jSRuntime;
        }

        private async Task WaitForReference() {
            if (!_accessorJsRef.IsValueCreated ) {
                _accessorJsRef = new(await _jsRuntime.InvokeAsync<IJSObjectReference>
                ("import", "/js/LocalStorageAccessor.js") );
            }
        }

        public async ValueTask DisposeAsync()
        {
            if(_accessorJsRef.IsValueCreated) {
                await _accessorJsRef.Value.DisposeAsync();
            }
        }
    }
}