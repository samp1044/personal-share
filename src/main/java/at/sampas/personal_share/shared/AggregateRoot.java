package at.sampas.personal_share.shared;

import java.util.ArrayList;
import java.util.List;

public abstract class AggregateRoot<T> {
    private final List<Event> events = new ArrayList<>();

    protected void publish(Event e) {
        events.add(e);
    }

    public List<Event> getEvents() {
        return events;
    }

    public abstract T getId();
}
